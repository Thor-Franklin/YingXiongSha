// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDragDropManager.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.DragDrop
{
    public interface IDragDropManager
    {
        #region Public Methods and Operators

        DragDropOperation GetDragDropOperation(int pointerId);

        #endregion
    }
}