using DataBind.Core.Presentation;
using UI.Windows;
using UnityEngine;
public class WindowContextInitializer : MonoBehaviour
{
    #region Fields

    public WindowManager WindowManager;

    #endregion

    #region Methods

    protected void OnDisable()
    {
        if (this.WindowManager != null)
        {
            this.WindowManager.WindowOpened -= this.OnWindowOpened;
        }
    }

    protected void OnEnable()
    {
        if (this.WindowManager != null)
        {
            this.WindowManager.WindowOpened += this.OnWindowOpened;
        }
    }

    private void OnWindowOpened(Window window)
    {
        if (window.Context == null)
        {
            return;
        }

        foreach (var root in window.Roots)
        {
            // Initialize window root with context.
            var contextHolder = root.GetComponent<ContextHolder>();
            if (contextHolder == null)
            {
                contextHolder = root.gameObject.AddComponent<ContextHolder>();
            }
            contextHolder.SetContext(window.Context, null);
        }
    }

    #endregion
}