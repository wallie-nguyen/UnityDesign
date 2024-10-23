using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringEventListener : MonoBehaviour, IEventListener
{
    public void TriggerEvent(IEventParameter parameter)
    {
        StringEventParameter stringEventParameter = (StringEventParameter)parameter;
        Debug.Log(stringEventParameter.Value);
    }
}
