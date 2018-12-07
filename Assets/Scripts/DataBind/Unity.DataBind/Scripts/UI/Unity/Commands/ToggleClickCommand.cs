using DataBind.UI.Unity.Commands;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ToggleClickCommand : UnityEventCommand<Toggle, bool>
    {
        protected override UnityEvent<bool> GetEvent(Toggle target)
        {
            return target.onValueChanged;
        }
    }
}