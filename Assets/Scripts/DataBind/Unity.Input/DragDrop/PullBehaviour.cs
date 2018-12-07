// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PullBehaviour.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.DragDrop
{
    using UnityEngine;

    public class PullBehaviour : MonoBehaviour
    {
        #region Fields

        public bool IgnoreDragOffset;

        public Transform Target;

        private Vector2 currentScreenPosition;

        private Vector3 dragOffset;

        private Vector3 initialPosition;

        private bool isDragging;

        #endregion

        #region Public Methods and Operators

        public void ContinuePull(Vector2 pointerPosition, Vector2 moveDelta)
        {
            this.currentScreenPosition = pointerPosition;
            this.UpdateTargetPosition();
        }

        public void EndPull()
        {
            this.isDragging = false;

            this.ResetPosition();

            var canvasGroup = this.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = true;
            }
        }

        public void ResetPosition()
        {
            this.Target.position = this.initialPosition;
        }

        public void StartPull(Vector2 pointerPosition)
        {
            this.isDragging = true;

            this.currentScreenPosition = pointerPosition;
            this.initialPosition = this.Target.position;
            this.dragOffset = this.initialPosition - this.ConvertScreenPosition(pointerPosition);

            var canvasGroup = this.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = false;
            }
        }

        #endregion

        #region Methods

        protected virtual Vector3 ConvertScreenPosition(Vector2 screenPosition)
        {
            return new Vector3(screenPosition.x, screenPosition.y);
        }

        protected virtual void Reset()
        {
            if (this.Target == null)
            {
                this.Target = this.transform;
            }
        }

        protected void Update()
        {
            if (this.isDragging)
            {
                this.UpdateTargetPosition();
            }
        }

        private void UpdateTargetPosition()
        {
            if (this.Target == null)
            {
                return;
            }

            var targetPosition = this.ConvertScreenPosition(this.currentScreenPosition);
            if (!this.IgnoreDragOffset)
            {
                targetPosition += this.dragOffset;
            }

            this.Target.position = targetPosition;
        }

        #endregion
    }
}