using System.Collections;
using System.Collections.Generic;
using UI.Windows;
using UnityEngine;

namespace UI.Windows
{
    public class MainWindow : MonoBehaviour
    {

        #region Fields

        public string MainWindowId = "Main";

        #endregion

        #region Methods

        protected void Start()
        {
            // Load main window.
            WindowManager.Instance.OpenWindow(this.MainWindowId);
        }

        #endregion
    }
}
