using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;


// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextTextSetter.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DataBind.UI.Unity.Setters
{
    using DataBind.Foundation.Setters;

    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    ///   Set the text of a Text depending on the string data value.
    /// </summary>
    [AddComponentMenu("Data Bind/UnityUI/Setters/[DB] Text Text Extend Setter (Unity)")]
    public class TextTextExtSetter : ComponentSingleSetter<Text, int>
    {
        #region Methods

        /// <summary>
        ///   Called when the data binding value changed.
        /// </summary>
        /// <param name="newValue">New data value.</param>
        protected override void OnValueChanged(int newValue)
        {
            if (this.Target != null)
            {
                this.Target.text = GetPriceStr(newValue);
            }
        }
        private string GetPriceStr(float price)
        {
            if (price >= 1000 * 100 && price < 1000 * 1000 * 100)
            {
                string str = (price / 1000f).ToString(CultureInfo.InvariantCulture);
                StringBuilder sb = new StringBuilder();
                if (str.Length >= 5)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i >= 5 || str[i] == '.')
                            break;
                        sb.Append(str[i]);
                    }
                }
                else
                {
                    return str+"K";
                }
                return sb.ToString() + "K";
            }
            if (price >= 1000 * 1000 * 100 && price <= 1000 * 1000 * 10000f)
            {
                string str = (price / 1000 * 1000f).ToString(CultureInfo.InvariantCulture);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 4 && str[i] == '.')
                        break;
                    sb.Append(str[i]);
                }
                return sb.ToString() + "M";
            }
            if (price >= 1000 * 1000 * 1000 && price <= 1000 * 1000 * 1000 * 1000f)
            {
                return (int)(price / (10000 * 1000 * 1000f)) + "B";
            }
            return price.ToString();
        }
        #endregion
    }
}
