using System.Collections;
using UnityEngine;
using Chars.Tools;
using UnityEngine.SceneManagement;

namespace Onion
{
    public class GameController : Singleton<GameController>
    {
        public enum Status { BeforeGameStart, GameInProgress, GameOver };
        public Status CurrentStatus;
        public Counter points;
        public Counter tears;
        public bool firstLayerRemoved = false;
        public OnionEntity onionEntity;        
        public float highScore = 0;
        public Timer timer;
        [SerializeField] private int startTime = 3600;

		protected void Start()
		{
			Application.targetFrameRate = 60;
			SetStatus(Status.GameInProgress);
            timer.SetInitialTime(startTime);
            timer.StartTimer();
        }

        public void SetStatus(Status value) => CurrentStatus = value;
        public void AddTears(float value)
        {
            if (CurrentStatus != Status.GameInProgress)
                return;

            if (points.GetValue() > 0 && !firstLayerRemoved)
                firstLayerRemoved = true;

            tears.Add(value);
        }

        public void CleanTears()
        {
            if (CurrentStatus != Status.GameInProgress)
                return;

            if (tears.GetValue() > 0)
            {
                tears.SetCurrentValue(tears.GetValue() / 2);
            }
            else
            {
                tears.SetCurrentValue(0);
            }
        }

        protected virtual void Update()
        {
            if (CurrentStatus == Status.GameOver) 
                timer.StopTimer();

            if (CurrentStatus != Status.GameInProgress) 
                return;

            if (firstLayerRemoved)
                AddTears(0.05f);
         
            HandleGameOver();
        }

        private void HandleGameOver()
        {
            if (timer.CurrentState == Timer.TimerState.Finish)
            {
                SetHighScorePlayerPref(points.GetValue());
                SetStatus(Status.GameOver);
                EventBus.TriggerEvent(new GameEvent("GameOver"));
            }
        }
        
        public void SetHighScorePlayerPref(float highScore)
        {
            if (!PlayerPrefs.HasKey("highScore"))
            {
                PlayerPrefs.SetFloat("highScore", 0);
            }
            else if (PlayerPrefs.GetFloat("highScore") < highScore)
            {
                PlayerPrefs.SetFloat("highScore", highScore);
            }            
        }

    }
}