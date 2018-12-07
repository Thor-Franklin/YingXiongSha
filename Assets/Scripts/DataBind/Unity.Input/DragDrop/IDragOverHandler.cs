// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDragOverHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.DragDrop
{
    using UnityEngine.EventSystems;

    public interface IDragOverHandler : IEventSystemHandler
    {
        #region Public Methods and Operators

        void OnDragOver(PointerEventData eventData);

        #endregion
    }
}