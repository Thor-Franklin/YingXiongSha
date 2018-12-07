namespace DataBind.UI.Unity.Getters
{
    using Foundation.Providers.Getters;
    using UnityEngine.UI;
    using UnityEngine;
    

    /// <summary>
    ///   Provides a boolean value if a toggle is on.
    /// </summary>
    public class ToggleIsOnGameObjectGetter : ComponentSingleGetter<Toggle, GameObject>
    {
        #region Methods

        /// <summary>
        ///     Register listener at target to be informed if its value changed.
        ///     The target is already checked for null reference.
        /// </summary>
        /// <param name="target">Target to add listener to.</param>
        protected override void AddListener(Toggle target)
        {
            target.onValueChanged.AddListener(this.OnToggleValueChanged);
        }

        /// <summary>
        ///     Derived classes should return the current value to set if this method is called.
        ///     The target is already checked for null reference.
        /// </summary>
        /// <param name="target">Target to get value from.</param>
        /// <returns>Current value to set.</returns>
        protected override GameObject GetValue(Toggle target)
        {            
            return target.gameObject;
        }

        /// <summary>
        ///     Remove listener from target which was previously added in AddListener.
        ///     The target is already checked for null reference.
        /// </summary>
        /// <param name="target">Target to remove listener from.</param>
        protected override void RemoveListener(Toggle target)
        {
            target.onValueChanged.RemoveListener(this.OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool newValue)
        {
            this.OnTargetValueChanged();
        }

        #endregion
    }
}