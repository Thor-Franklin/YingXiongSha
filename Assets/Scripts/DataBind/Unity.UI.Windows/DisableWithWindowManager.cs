// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisableWithWindowManager.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Windows
{
    using UnityEngine;

    /// <summary>
    ///   Disables the game object the script is on if a window manager is found.
    ///   Useful if you test scenes separately and need e.g. a camera which is normally
    ///   initialized in a root scene.
    /// </summary>
    [AddComponentMenu("Slash/Windows/Editor/DisableWithWindowManager")]
    public class DisableWithWindowManager : MonoBehaviour
    {
        #region Methods

        private void Awake()
        {
            if (WindowManager.Instance != null)
            {
                this.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}