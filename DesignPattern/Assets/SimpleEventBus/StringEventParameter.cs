using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringEventParameter : IEventParameter
{
    public string Value { get; private set; }

    public StringEventParameter(string value)
    {
        Value = value;
    }
}
