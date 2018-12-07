// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWindowClosingHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Windows
{
    using System;

    /// <summary>
    ///   Interface for a handler which does further actions (e.g. playing an animation) when a window should be closed.
    ///   The handler has to make sure to invoke the callback when it has finished with its actions.
    /// </summary>
    public interface IWindowClosingHandler
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Called when the window was closed.
        /// </summary>
        /// <param name="closingFinishedCallback">This callback has to be called when the handler has finished with its actions.</param>
        void OnWindowClosed(Action closingFinishedCallback);

        #endregion
    }
}