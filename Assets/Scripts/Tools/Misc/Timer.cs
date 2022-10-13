using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Chars.Tools
{
    public class Timer : MonoBehaviour
    {
        public enum TimerState
        {
            Initial,
            Running,
            Paused,
            Finish
        }
        public enum TimerType {
            Seconds,
            MinutesSeconds,
            MinutesSecondsAndMilliseconds,
            HoursMinutesSecondsMilliSeconds,
            HoursMinutesSeconds,
            HoursMinutes
        }
        public enum TimerMode
        {
            Add,
            Substract
        }

        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private float initialTime;
        [SerializeField] private float currentTime;
        [SerializeField] private TimerType currentType = TimerType.HoursMinutesSeconds;
        [SerializeField] private TimerState currentState;
        [SerializeField] private TimerMode currentMode;
        [SerializeField] private float speed;

        public TimerState CurrentState => currentState;

        private float Hours => Mathf.FloorToInt((currentTime / 3600) % 24);
        private float Minutes => Mathf.FloorToInt((currentTime / 60) % 60);
        private float Seconds => Mathf.FloorToInt(currentTime % 60);
        private float MilliSeconds => (currentTime % 1) * 1000;

        private void Start()
        {
            //SetTimerState(TimerState.Initial);
        }

        private void Update()
        {
            if (currentState == TimerState.Running)
            {
                UpdateTimer();
                SetTimeText();
            }
        }

        public void StartTimer() {
            currentTime = initialTime;
            this.currentState = TimerState.Running;
        }

        public void StopTimer() => SetTimerState(TimerState.Paused);

        public void SetInitialTime(float value) => initialTime = value;

        private void SetTimeText() => timer.text = GetTimeFormat(currentTime);

        public void UpdateTimer() 
        {
            if (currentTime > 0)
            {
                if (currentMode == TimerMode.Substract)
                {
                    currentTime -= Time.deltaTime * speed;
                }
                else if (currentMode == TimerMode.Add)
                {
                    currentTime += Time.deltaTime * speed;
                }
            }
            else
            {
                currentTime = 0;
                this.currentState = TimerState.Finish;
            }
        }

        public void SetTime(float newTime) => currentTime = newTime;

        public void SetTimerType(TimerType type) => currentType = type;

        public TimerType GetTimerType() { return currentType; }

        public void SetTimerState(TimerState state) => currentState = state;

        private string GetTimeFormat(float time)
        {
            string format = string.Empty;
            switch (currentType)
            {
                case TimerType.Seconds:
                    format = $"{Seconds}";
                    break;
                case TimerType.MinutesSeconds:
                    format = $"{Minutes:00}:{Seconds:00}";
                    break;
                case TimerType.HoursMinutes:
                    format = $"{Hours:00}:{Minutes:00}";
                    break;
                case TimerType.HoursMinutesSeconds:
                    format = $"{Hours:00}:{Minutes:00}:{Seconds:00}";
                    break;
                case TimerType.MinutesSecondsAndMilliseconds:
                    format = $"{Minutes:00}:{Seconds:00}:{MilliSeconds:000}";
                    break;
                case TimerType.HoursMinutesSecondsMilliSeconds:
                    format = $"{Hours:00}:{Minutes:00}:{Seconds:00}:{MilliSeconds:000}";
                    break;
            }
            return format;
        }


    }
}