// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragDropOperation.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Input.DragDrop
{
    using UnityEngine;

    public class DragDropOperation
    {
        #region Properties

        /// <summary>
        ///   Data depending on specific drag drop operation.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        ///   Dragged game object.
        /// </summary>
        public GameObject DragObject { get; set; }

        /// <summary>
        ///   Game object the dragged one was dropped on.
        /// </summary>
        public GameObject DropObject { get; set; }

        /// <summary>
        ///   Indicats if the drag drop operation will be/was successful.
        /// </summary>
        public bool DropSuccessful { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Reset()
        {
            this.Data = null;
            this.DragObject = null;
            this.DropObject = null;
            this.DropSuccessful = false;
        }

        #endregion
    }
}