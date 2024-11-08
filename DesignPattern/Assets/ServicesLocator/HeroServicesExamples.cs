using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityServicesLocator;

public class HeroServicesExamples : MonoBehaviour
{
    ILocalization localization;
    ISerializer serializer;
    IAudioService audioService;
    IGameService gameService;

    private void Awake()
    {
        ServiceLocator.Global.Register<ILocalization>(new MockLocalization());
        ServiceLocator.ForSceneOf(this).Register<ISerializer>(new MockSerializer());
        ServiceLocator.For(this).Register<IAudioService>(new MockAudioService());
    }

    private void Start()
    {
        ServiceLocator.For(this).Get(out localization).Get(out serializer).Get(out audioService).Get(out gameService);
        localization.GetText("key1");
        serializer.Serialize();
        audioService.PlaySound();
        gameService.StartGame();
    }
}