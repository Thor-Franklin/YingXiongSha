using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ValueChange
{
    static readonly Dictionary<object, ValueChangeEvent> Dictionary = new Dictionary<object, ValueChangeEvent>();
    public static void Register<T>(this T obj, Action<object> valueChangeEvent)
    {
        if (!Dictionary.ContainsKey(obj))
        {
            Dictionary.Add(obj, new ValueChangeEvent());
        }
        Dictionary[obj].Add(valueChangeEvent);
    }

    public static void Send<T>(T obj)
    {
        if (Dictionary.ContainsKey(obj))
        {
            Dictionary[obj].Invoke(obj);
        }
    }
}

public class ValueChangeEvent
{
    public void Invoke(object obj)
    {
        _notifyEvent.Invoke(obj);
    }

    private Action<object> _notifyEvent;
    public void Add(Action<object> valueChangeEvent)
    {
        _notifyEvent += valueChangeEvent;
    }

}