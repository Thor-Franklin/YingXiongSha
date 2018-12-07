﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransformRotationSetter.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace DataBind.Foundation.Setters
{
    /// <summary>
    ///     Sets the rotation of a transform depending on a data value.
    /// </summary>
    [AddComponentMenu("Data Bind/Foundation/Setters/[DB] Transform Rotation Setter")]
    public class TransformRotationSetter : ComponentSingleSetter<Transform, Quaternion>
    {
        /// <summary>
        ///   Called when the data binding value changed.
        /// </summary>
        /// <param name="newValue">New data value.</param>
        protected override void OnValueChanged(Quaternion newValue)
        {
            this.Target.rotation = newValue;
        }
    }
}