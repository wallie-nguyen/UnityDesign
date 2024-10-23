using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleUsageEventBus : MonoBehaviour
{
    [SerializeField]
    private EventBus eventBus;

    private StringEventListener myEventListener;

    private void Start()
    {
        myEventListener = new();
        eventBus.RegisterListener<StringEventParameter>(myEventListener);
    }

    private void OnDestroy()
    {
        eventBus.UnregisterListener<StringEventParameter>(myEventListener);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventBus.TriggerEvent(new StringEventParameter("Hello, World!"));
        }
    }
}
