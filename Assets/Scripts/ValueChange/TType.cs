using System.Collections.Generic;
using UnityEngine;

public class IntType : TType<int>
{
    public IntType(int value)
    {
        Value = value;
    }
}

public class IntListType : TType<List<int>>
{
    public IntListType(List<int> value)
    {
        Value = value;
    }

    public void Add(int value)
    {
        Value.Add(value);
        ValueChange.Send(this);
    }

    public bool Contains(int value)
    {
        return Value.Contains(value);
    }
}

public class GameObjListType:TType <List<GameObject>>
{
    public GameObjListType(List<GameObject> value =null)
    {
        Value = value;      
    }

    public void Add(GameObject value)
    {
        Value.Add(value);
        ValueChange.Send(this);
    }

    public void Remove(GameObject value)
    {
        Value.Remove(value);
        ValueChange.Send(this);
    }
}

public class StringType : TType<string>
{
    public StringType(string value)
    {
        Value = value;
    }
}

public class FloatType : TType<float>
{
  

}


public class BoolType : TType<bool>
{
    public BoolType(bool value)
    {
        Value = value;
    }
}


public delegate void ValueChangeEventHandler<T>(T t);
public class TType<T> 
{
    public T Value { get; protected set; }

    public void Set(T value)
    {
        if (!Equals(Value, value))
        {
            Value = value;
            ValueChange.Send(this);
        }
    }
}
