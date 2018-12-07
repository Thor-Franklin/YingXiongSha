﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoundToNearestOperation.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.Foundation.Providers.Operations
{
    using System;

    using DataBind.Core.Presentation;

    using UnityEngine;

    /// <summary>
    ///   Rounds the data value to the nearest multiple integer value.
    ///   <para>Input: Number</para>
    ///   <para>Output: Integer</para>
    /// </summary>
    [AddComponentMenu("Data Bind/Foundation/Formatters/[DB] Round To Nearest Operation")]
    public class RoundToNearestOperation : DataProvider
    {
        #region Fields

        /// <summary>
        ///   Data value to round.
        /// </summary>
        public DataBinding Argument;

        /// <summary>
        ///   Multiple to round to, default: 1.
        /// </summary>
        [Tooltip("Multiple to round to, default: 1")]
        public int ToNearest = 1;

        #endregion

        #region Properties

        /// <summary>
        ///   Current data value.
        /// </summary>
        public override object Value
        {
            get
            {
                var argument = this.Argument.GetValue<float>();
                return ((int)Math.Round(argument / this.ToNearest)) * this.ToNearest;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Unity callback.
        /// </summary>
        protected void Awake()
        {
            // Add bindings.
            this.AddBinding(this.Argument);
        }

        /// <summary>
        ///   Called when the value of the data provider should be updated.
        /// </summary>
        protected override void UpdateValue()
        {
            this.OnValueChanged(this.Value);
        }

        #endregion
    }
}