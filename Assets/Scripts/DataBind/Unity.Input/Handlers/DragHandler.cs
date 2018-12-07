// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.Handlers
{
    using System;

    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Fields

        public BeginDragEvent BeginDrag;

        public DragEvent Drag;

        public EndDragEvent EndDrag;

        private PointerEventData dragPointerEventData;

        private bool isDragging;

        #endregion

        #region Public Methods and Operators

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.BeginDrag.Invoke(eventData.position);
            this.isDragging = true;
            this.dragPointerEventData = eventData;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.Drag.Invoke(eventData.position, eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.EndDrag.Invoke(eventData.position);
            this.isDragging = false;
            this.dragPointerEventData = null;
        }

        #endregion

        #region Methods

        protected void OnDisable()
        {
            if (this.isDragging)
            {
                this.OnEndDrag(this.dragPointerEventData);
            }
        }

        #endregion

        [Serializable]
        public class BeginDragEvent : UnityEvent<Vector2>
        {
        }

        [Serializable]
        public class DragEvent : UnityEvent<Vector2, Vector2>
        {
        }

        [Serializable]
        public class EndDragEvent : UnityEvent<Vector2>
        {
        }
    }
}