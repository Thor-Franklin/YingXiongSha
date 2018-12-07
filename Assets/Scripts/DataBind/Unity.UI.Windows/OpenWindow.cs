using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Windows
{
    public class OpenWindow : MonoBehaviour
    {
        #region Fields

        public string WindowId;

        #endregion

        #region Public Methods and Operators

        public void Execute()
        {
            if (WindowManager.Instance != null)
            {
                if (!string.IsNullOrEmpty(this.WindowId))
                {
                    WindowManager.Instance.OpenWindow(this.WindowId);
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
    }
}
