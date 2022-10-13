using Chars.Tools;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Onion
{
    public class UIController : Singleton<UIController>, EventListener
    {
       // [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private Slider tearsBar ;
        [SerializeField] private TextMeshProUGUI points;
        [SerializeField] private Button cleanTearsButton;
        [SerializeField] private GameObject panelGameOver;
        [SerializeField] private Texture2D cursorNormal;
        [SerializeField] private Texture2D cursorDrag;
        [SerializeField] private CursorMode cursorMode = CursorMode.ForceSoftware;
        [SerializeField] private GameObject popupText;
        [SerializeField] private Canvas UICanvas;
        [SerializeField] private Text highScoreText;
        [SerializeField] private TrailRenderer trailrenderer;
        public DiagnalParallax diagnal;

        protected override void Awake()
        {
            SetCursorNormal();
        }

        public void SetCursorNormal()
        {
            Cursor.SetCursor(cursorNormal, Vector2.zero, cursorMode);
        }

        public void SetCursorDrag()
        {
            Cursor.SetCursor(cursorDrag, Vector2.zero, cursorMode);
        }


        public void OnEvent(GameEvent eventType)
        {
            switch (eventType.name)
            {
                case "GameOver":
                    ShowGameOver();
                break;                               
                default:
                    break;
            }
        }

        protected virtual void OnEnable()
        {
            this.EventStartListening();
        }

        protected virtual void OnDisable()
        {
            this.EventStopListening();
        }        
      

        public void Update()
        {
            points.text = GameController.instance.points.GetValue().ToString();
            tearsBar.value = GameController.instance.tears.GetValue() / 100 ;           
        }


        private void ShowGameOver()
        {
            panelGameOver.SetActive(true);
            highScoreText.text = ($"HighScore: { PlayerPrefs.GetFloat("highScore") }");
        }

        private void HideGameOver()
        {
            panelGameOver.SetActive(false);
        }

        public void InstantiateFloatingText()
        {
            GameObject.Instantiate(popupText, Vector3.zero, Quaternion.identity, UICanvas.transform);
        }

        public void ShowTrailRenderer()
        {
            trailrenderer.enabled = true;
        }

        public void HideTrailRenderer()
        {
            trailrenderer.enabled = false;
        }
    }
}