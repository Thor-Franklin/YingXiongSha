// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragOperationHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.Handlers
{
    using System;

    using Input.DragDrop;

    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class DragOperationHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Fields

        public DragDropOperationEvent DropWillBeSuccessful;

        public DragDropOperationEvent DropWillBeUnsuccessful;

        public StartDragDropEvent StartDragDrop;

        public SuccessfulDragDropEvent SuccessfulDragDrop;

        public UnsuccessfulDragDropEvent UnsuccessfulDragDrop;

        /// <summary>
        ///   Indicates if the drop will be successful.
        ///   Stored to know when the drop result changed.
        /// </summary>
        private bool dropSuccessful;

        #endregion

        #region Public Methods and Operators

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.dropSuccessful = false;

            // Get drag drop operation.
            var dragDropOperation = GetDragDropOperation(eventData);
            if (dragDropOperation != null)
            {
                if (this.StartDragDrop != null)
                {
                    // Start drag drop operation.
                    this.StartDragDrop.Invoke(dragDropOperation);
                }

                // Initial call if drop will be successful.
                this.dropSuccessful = dragDropOperation.DropSuccessful;
                if (this.dropSuccessful)
                {
                    this.DropWillBeSuccessful.Invoke(dragDropOperation);
                }
                else
                {
                    this.DropWillBeUnsuccessful.Invoke(dragDropOperation);
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Get drag drop operation.
            var dragDropOperation = GetDragDropOperation(eventData);
            if (dragDropOperation != null)
            {
                this.UpdateDropSuccessful(dragDropOperation);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Get drag drop operation.
            var dragDropOperation = GetDragDropOperation(eventData);
            if (dragDropOperation != null)
            {
                this.UpdateDropSuccessful(dragDropOperation);
                if (dragDropOperation.Data != null)
                {
                    if (dragDropOperation.DropSuccessful)
                    {
                        this.SuccessfulDragDrop.Invoke(dragDropOperation.Data);
                    }
                    else
                    {
                        this.UnsuccessfulDragDrop.Invoke(dragDropOperation.Data);
                    }
                }
            }

            this.dropSuccessful = false;
        }

        #endregion

        #region Methods

        private static DragDropOperation GetDragDropOperation(PointerEventData eventData)
        {
            var dragDropManager = eventData.currentInputModule as IDragDropManager;
            return dragDropManager != null ? dragDropManager.GetDragDropOperation(eventData.pointerId) : null;
        }

        private void UpdateDropSuccessful(DragDropOperation operation)
        {
            if (operation.DropSuccessful == this.dropSuccessful)
            {
                return;
            }

            this.dropSuccessful = operation.DropSuccessful;

            if (this.dropSuccessful)
            {
                this.DropWillBeSuccessful.Invoke(operation);
            }
            else
            {
                this.DropWillBeUnsuccessful.Invoke(operation);
            }
        }

        #endregion

        [Serializable]
        public class DragDropOperationEvent : UnityEvent<DragDropOperation>
        {
        }

        [Serializable]
        public class StartDragDropEvent : UnityEvent<DragDropOperation>
        {
        }

        [Serializable]
        public class SuccessfulDragDropEvent : UnityEvent<object>
        {
        }

        [Serializable]
        public class UnsuccessfulDragDropEvent : UnityEvent<object>
        {
        }
    }
}