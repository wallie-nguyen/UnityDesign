using System;
using UnityEngine;
using UnityServicesLocator;

public class OtherGameObject : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.For(this).Register<IGameService>(new MockGameService());
    }
}