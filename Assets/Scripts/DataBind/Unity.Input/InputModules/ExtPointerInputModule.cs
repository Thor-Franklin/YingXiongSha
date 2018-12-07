// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtPointerInputModule.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.InputModules
{
    using System.Collections.Generic;

    using Input.DragDrop;

    using UnityEngine;
    using UnityEngine.EventSystems;

    public abstract class ExtPointerInputModule : PointerInputModule, IDragDropManager
    {
        #region Fields

        private readonly Dictionary<int, DragDropOperation> dragDropOperations =
            new Dictionary<int, DragDropOperation>();

        #endregion

        #region Constructors and Destructors

        static ExtPointerInputModule()
        {
            DragOverHandler = Execute;
        }

        #endregion

        #region Properties

        private static ExecuteEvents.EventFunction<IDragOverHandler> DragOverHandler { get; set; }

        #endregion

        #region Public Methods and Operators

        public DragDropOperation GetDragDropOperation(int pointerId)
        {
            DragDropOperation operation;
            this.dragDropOperations.TryGetValue(pointerId, out operation);
            return operation;
        }

        public Vector2 GetPointerPosition(int pointerId)
        {
            PointerEventData pointerEventData;
            this.GetPointerData(pointerId, out pointerEventData, false);
            return pointerEventData != null ? pointerEventData.position : Vector2.zero;
        }

        #endregion

        #region Methods

        protected void ProcessDragDrop(PointerEventData pointerEvent)
        {
            var moving = pointerEvent.IsPointerMoving();
            var beginDragging = moving && !pointerEvent.dragging
                                && ShouldStartDrag(
                                    pointerEvent.pressPosition,
                                    pointerEvent.position,
                                    this.eventSystem.pixelDragThreshold,
                                    pointerEvent.useDragThreshold);
            if (beginDragging)
            {
                // Update object to drag on begin drag.
                var currentOverGo = pointerEvent.pointerCurrentRaycast.gameObject;
                pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(currentOverGo);

                if (pointerEvent.pointerDrag != null)
                {
                    // Create new drag drop operation.
                    var dragDropOperation = this.GetOrCreateDragDropOperation(pointerEvent.pointerId);
                    dragDropOperation.Reset();
                    dragDropOperation.DragObject = pointerEvent.pointerDrag;
                }
            }

            if (pointerEvent.dragging)
            {
                // Update drop object of drag drop operation.
                var dragDropOperation = this.GetDragDropOperation(pointerEvent.pointerId);
                if (dragDropOperation != null)
                {
                    var currentOverGo = pointerEvent.pointerCurrentRaycast.gameObject;
                    var dropObject = ExecuteEvents.GetEventHandler<IDropHandler>(currentOverGo);
                    if (dropObject != dragDropOperation.DropObject)
                    {
                        dragDropOperation.DropObject = dropObject;
                        if (dragDropOperation.DropObject != null)
                        {
                            ExecuteEvents.Execute(dragDropOperation.DropObject, pointerEvent, DragOverHandler);
                        }
                        else
                        {
                            dragDropOperation.DropSuccessful = false;
                        }
                    }
                }
            }
        }

        protected void ProcessPress(PointerEventData pointerEvent, bool pressed, bool released)
        {
            var currentOverGo = pointerEvent.pointerCurrentRaycast.gameObject;

            // PointerDown notification
            if (pressed)
            {
                pointerEvent.eligibleForClick = true;
                pointerEvent.delta = Vector2.zero;
                pointerEvent.dragging = false;
                pointerEvent.useDragThreshold = true;
                pointerEvent.pressPosition = pointerEvent.position;
                pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;

                this.DeselectIfSelectionChanged(currentOverGo, pointerEvent);

                if (pointerEvent.pointerEnter != currentOverGo)
                {
                    // send a pointer enter to the touched element if it isn't the one to select...
                    this.HandlePointerExitAndEnter(pointerEvent, currentOverGo);
                    pointerEvent.pointerEnter = currentOverGo;
                }

                // search for the control that will receive the press
                // if we can't find a press handler set the press
                // handler to be what would receive a click.
                var newPressed = ExecuteEvents.ExecuteHierarchy(
                    currentOverGo,
                    pointerEvent,
                    ExecuteEvents.pointerDownHandler);

                // didnt find a press handler... search for a click handler
                if (newPressed == null)
                {
                    newPressed = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);
                }

                // Debug.Log("Pressed: " + newPressed);

                float time = Time.unscaledTime;

                if (newPressed == pointerEvent.lastPress)
                {
                    var diffTime = time - pointerEvent.clickTime;
                    if (diffTime < 0.3f)
                    {
                        ++pointerEvent.clickCount;
                    }
                    else
                    {
                        pointerEvent.clickCount = 1;
                    }

                    pointerEvent.clickTime = time;
                }
                else
                {
                    pointerEvent.clickCount = 1;
                }

                pointerEvent.pointerPress = newPressed;
                pointerEvent.rawPointerPress = currentOverGo;

                pointerEvent.clickTime = time;

                // Save the drag handler as well
                pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(currentOverGo);

                if (pointerEvent.pointerDrag != null)
                {
                    ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
                }
            }

            // PointerUp notification
            if (released)
            {
                // Debug.Log("Executing pressup on: " + pointer.pointerPress);
                ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);

                // Debug.Log("KeyCode: " + pointer.eventData.keyCode);

                // see if we mouse up on the same element that we clicked on...
                var pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);

                // PointerClick and Drop events
                if (pointerEvent.pointerPress == pointerUpHandler && pointerEvent.eligibleForClick)
                {
                    ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
                }
                else if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
                {
                    ExecuteEvents.ExecuteHierarchy(currentOverGo, pointerEvent, ExecuteEvents.dropHandler);
                }

                pointerEvent.eligibleForClick = false;
                pointerEvent.pointerPress = null;
                pointerEvent.rawPointerPress = null;

                if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
                {
                    ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
                }

                pointerEvent.dragging = false;
                pointerEvent.pointerDrag = null;

                // send exit events as we need to simulate this on touch up on touch device
                ExecuteEvents.ExecuteHierarchy(
                    pointerEvent.pointerEnter,
                    pointerEvent,
                    ExecuteEvents.pointerExitHandler);
                pointerEvent.pointerEnter = null;
            }
        }

        private static void Execute(IDragOverHandler handler, BaseEventData eventData)
        {
            handler.OnDragOver(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
        }

        private DragDropOperation GetOrCreateDragDropOperation(int pointerId)
        {
            DragDropOperation operation;
            if (!this.dragDropOperations.TryGetValue(pointerId, out operation))
            {
                operation = new DragDropOperation();
                this.dragDropOperations[pointerId] = operation;
            }
            return operation;
        }

        private static bool ShouldStartDrag(
            Vector2 pressPos,
            Vector2 currentPos,
            float threshold,
            bool useDragThreshold)
        {
            if (!useDragThreshold)
            {
                return true;
            }

            return (pressPos - currentPos).sqrMagnitude >= threshold * threshold;
        }

        #endregion
    }
}