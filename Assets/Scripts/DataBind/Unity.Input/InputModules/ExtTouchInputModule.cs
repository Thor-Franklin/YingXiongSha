// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtTouchInputModule.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.InputModules
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class ExtTouchInputModule : ExtPointerInputModule
    {
        #region Fields

        [SerializeField]
        private bool forceModuleActive;

        private Vector2 lastMousePosition;

        private Vector2 mousePosition;

        #endregion

        #region Delegates

        /// <summary>
        ///   Delegate for the Pressed event.
        /// </summary>
        /// <param name="pointerId">Id of pressed pointer.</param>
        public delegate void PressedDelegate(int pointerId);

        #endregion

        #region Events

        /// <summary>
        ///   Called when a pointer is pressed.
        /// </summary>
        public event PressedDelegate Pressed;

        #endregion

        #region Properties

        public bool ForceModuleActive
        {
            get
            {
                return this.forceModuleActive;
            }
            set
            {
                this.forceModuleActive = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public override void DeactivateModule()
        {
            base.DeactivateModule();
            this.ClearSelection();
        }

        public override bool IsModuleSupported()
        {
            return this.ForceModuleActive || Input.touchSupported;
        }

        public override void Process()
        {
            if (this.UseFakeInput())
            {
                this.FakeTouches();
            }
            else
            {
                this.ProcessTouchEvents();
            }
        }

        public override bool ShouldActivateModule()
        {
            if (!base.ShouldActivateModule())
            {
                return false;
            }

            if (this.forceModuleActive)
            {
                return true;
            }

            if (this.UseFakeInput())
            {
                var wantsEnable = Input.GetMouseButtonDown(0);
                wantsEnable |= (this.mousePosition - this.lastMousePosition).sqrMagnitude > 0.0f;
                return wantsEnable;
            }

            for (var i = 0; i < Input.touchCount; ++i)
            {
                var input = Input.GetTouch(i);
                if (input.phase == TouchPhase.Began || input.phase == TouchPhase.Moved
                    || input.phase == TouchPhase.Stationary)
                {
                    return true;
                }
            }
            return false;
        }

        public override void UpdateModule()
        {
            this.lastMousePosition = this.mousePosition;
            this.mousePosition = Input.mousePosition;
        }

        #endregion

        #region Methods

        protected virtual void OnPressed(int pointerId)
        {
            var handler = this.Pressed;
            if (handler != null)
            {
                handler(pointerId);
            }
        }

        /// <summary>
        ///   For debugging touch-based devices using the mouse.
        /// </summary>
        private void FakeTouches()
        {
            var pointerData = this.GetMousePointerEventData(0);

            var leftPressData = pointerData.GetButtonState(PointerEventData.InputButton.Left).eventData;

            // fake touches... on press clear delta
            if (leftPressData.PressedThisFrame())
            {
                leftPressData.buttonData.delta = Vector2.zero;

                this.OnPressed(leftPressData.buttonData.pointerId);
            }

            this.ProcessPress(
                leftPressData.buttonData,
                leftPressData.PressedThisFrame(),
                leftPressData.ReleasedThisFrame());

            // only process move if we are pressed...
            if (Input.GetMouseButton(0))
            {
                this.ProcessMove(leftPressData.buttonData);
                this.ProcessDragDrop(leftPressData.buttonData);
                this.ProcessDrag(leftPressData.buttonData);
            }
        }

        /// <summary>
        ///   Process all touch events.
        /// </summary>
        private void ProcessTouchEvents()
        {
            for (var i = 0; i < Input.touchCount; ++i)
            {
                var input = Input.GetTouch(i);

                bool released;
                bool pressed;
                var pointer = this.GetTouchPointerEventData(input, out pressed, out released);

                if (pressed)
                {
                    // Invoke event.
                    this.OnPressed(pointer.pointerId);
                }

                this.ProcessPress(pointer, pressed, released);

                if (!released)
                {
                    this.ProcessMove(pointer);
                    this.ProcessDragDrop(pointer);
                    this.ProcessDrag(pointer);
                }
                else
                {
                    this.RemovePointerData(pointer);
                }
            }
        }

        private bool UseFakeInput()
        {
            return !Input.touchSupported;
        }

        #endregion
    }
}