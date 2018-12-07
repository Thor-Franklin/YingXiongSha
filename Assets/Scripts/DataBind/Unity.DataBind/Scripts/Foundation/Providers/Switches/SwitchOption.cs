namespace DataBind.Foundation.Providers.Switches
{
    using System;

    using DataBind.Core.Presentation;

    /// <summary>
    ///   Base class for an option of a RangeSwitch.
    /// </summary>
    [Serializable]
    public class SwitchOption
    {
        #region Fields

        /// <summary>
        ///   Value of this option.
        /// </summary>
        public DataBinding Value;

        #endregion
    }
}