using System.Collections;
using System.Collections.Generic;
using UI.Windows;
using UnityEngine;

namespace UI.Windows
{
    public class CloseWindow : MonoBehaviour
    {
        #region Fields

        [Tooltip("Id of window to close. Leave empty to close window this behaviour is part of.")]
        public string WindowId;

        #endregion

        #region Public Methods and Operators

        public void Execute()
        {
            if (WindowManager.Instance != null)
            {
                if (!string.IsNullOrEmpty(this.WindowId))
                {
                    WindowManager.Instance.CloseWindow(this.WindowId);
                }
                else
                {
                    Debug.LogWarning("No window id set.", this);
                }
            }
            else
            {
                Debug.LogWarning("No window manager found.", this);
            }
        }

        #endregion

        #region Methods

        protected void Awake()
        {
            // Use own scene to close.
            if (string.IsNullOrEmpty(this.WindowId))
            {
                this.WindowId = this.transform.gameObject.scene.name;
            }
        }

        #endregion
    }
}
