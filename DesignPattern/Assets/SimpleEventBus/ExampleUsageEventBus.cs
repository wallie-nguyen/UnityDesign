using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleUsageEventBus : MonoBehaviour
{
    [SerializeField]
    private EventBus eventBus;

    private void Start()
    {
        eventBus.RegisterListener<StringEventParameter>(HandleString);
    }

    private void OnDestroy()
    {
        eventBus.UnregisterListener<StringEventParameter>(HandleString);
    }

    private void HandleString(StringEventParameter eventParams)
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventBus.TriggerEvent(new StringEventParameter("Hello, World!"));
        }
    }
}
