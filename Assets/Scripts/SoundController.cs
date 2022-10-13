using System.Collections;
using UnityEngine;
using Chars.Tools;
using FMODUnity;

namespace Onion
{
    public class SoundController : Singleton<SoundController>, EventListener
    {
        [SerializeField] private StudioEventEmitter dragEmitter;
        [SerializeField] private StudioEventEmitter gameOverEmmiter;
        [SerializeField] private StudioEventEmitter retryEmmiter;
        [SerializeField] private StudioEventEmitter BackgroundEmmiter;

        public void OnEvent(GameEvent eventType)
        {
            switch (eventType.name)
            {
                case "GameOver":
                    BackgroundEmmiter.enabled = false;
                    break;
                default:
                    break;
            }
        }
    }
}