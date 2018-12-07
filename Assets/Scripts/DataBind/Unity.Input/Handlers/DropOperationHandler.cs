// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropOperationHandler.cs" company="Slash Games">
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

    public class DropOperationHandler : MonoBehaviour, IDropHandler, IDragOverHandler
    {
        #region Fields

        public DragOverEvent DragOver;

        public DropEvent Drop;

        #endregion

        #region Public Methods and Operators

        public void OnDragOver(PointerEventData eventData)
        {
            // Get drag drop operation.
            var dragDropOperation = GetDragDropOperation(eventData);
            if (dragDropOperation != null)
            {
                this.DragOver.Invoke(dragDropOperation);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            // Get drag drop operation.
            var dragDropOperation = GetDragDropOperation(eventData);
            if (dragDropOperation != null)
            {
                this.Drop.Invoke(dragDropOperation);
            }
        }

        #endregion

        #region Methods

        private static DragDropOperation GetDragDropOperation(PointerEventData eventData)
        {
            var dragDropManager = eventData.currentInputModule as IDragDropManager;
            return dragDropManager != null ? dragDropManager.GetDragDropOperation(eventData.pointerId) : null;
        }

        #endregion

        [Serializable]
        public class DropEvent : UnityEvent<DragDropOperation>
        {
        }

        [Serializable]
        public class DragOverEvent : UnityEvent<DragDropOperation>
        {
        }
    }
}