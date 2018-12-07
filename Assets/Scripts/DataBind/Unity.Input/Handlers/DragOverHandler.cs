// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragOverHandler.cs" company="Slash Games">
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

    public class DragOverHandler : MonoBehaviour, IDragOverHandler
    {
        #region Fields

        public DragOverEvent DragOver;

        #endregion

        #region Public Methods and Operators

        public void OnDragOver(PointerEventData eventData)
        {
            // Get drag drop operation.
            var dragDropManager = eventData.currentInputModule as IDragDropManager;
            if (dragDropManager != null)
            {
                var dragDropOperation = dragDropManager.GetDragDropOperation(eventData.pointerId);
                if (dragDropOperation != null)
                {
                    this.DragOver.Invoke(dragDropOperation);
                }
            }
        }

        #endregion

        [Serializable]
        public class DragOverEvent : UnityEvent<DragDropOperation>
        {
        }
    }
}