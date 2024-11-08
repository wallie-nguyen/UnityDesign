using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace UnityServicesLocator
{
    public interface ILocalization
    {
        string GetText(string key);
    }
    
    public class MockLocalization : ILocalization
    {
        readonly List<string> _keys = new List<string>
        {
            "key1",
            "key2",
            "key3",
            "key4",
            "key5",
            "key6",
            "key7",
            "key8",
            "key9",
            "key10",
        };

        private readonly System.Random randoms = new Random();
        
        public string GetText(string key)
        {
            Debug.Log("GetText");
            return _keys[randoms.Next(0, _keys.Count)];
        }
    }
    
    public interface ISerializer
    {
        void Serialize();
    }
    
    public class MockSerializer : ISerializer
    {
        public void Serialize()
        {
            Debug.Log("Serialize");
        }
    }
    
    public interface IAudioService
    {
        void PlaySound();
    }
    
    public class MockAudioService : IAudioService
    {
        public void PlaySound()
        {
            Debug.Log("PlaySound");
        }
    }
    
    public interface IGameService
    {
        void StartGame();
    }
    
    public class MockGameService : IGameService
    {
        public void StartGame()
        {
            Debug.Log("StartGame");
        }
    }
}