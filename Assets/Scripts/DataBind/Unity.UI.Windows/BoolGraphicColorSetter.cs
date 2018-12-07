using DataBind.Foundation.Setters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolGraphicColorSetter : ComponentSingleSetter<Graphic, bool>
{
    [SerializeField]
    private Color _trueColor;
    [SerializeField]
    private Color _falseColor;
    protected override void OnValueChanged(bool newValue)
    {
        if (this.Target != null)
        {
            this.Target.color = newValue ? _trueColor : _falseColor;
        }
    }
}

