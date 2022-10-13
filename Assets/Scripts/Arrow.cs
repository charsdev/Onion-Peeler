using UnityEngine;
using System.Collections.Generic;
using Chars.Tools;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using FMOD;
using FMODUnity;

namespace Onion
{
    public class Arrow : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler 
    {

        private float arrowDistance = 2;  
        private System.Random random = new System.Random();
        private int lastRandomIndex = 0;
        [SerializeField] private bool continuesDragging = false;
        [SerializeField] private StudioEventEmitter dragEmitter;

        private void Start()
        {
            SetArrowRotation();
            UIController.Instance.HideTrailRenderer();
            UIController.Instance.diagnal?.SetDirection(Trigonometry.angles[lastRandomIndex]);

        }

        private void Update()
        {
        }

        public void OnMouseEnter()
        {
            //if (GameController.Instance.CurrentStatus != GameController.Status.GameInProgress
            //    && !continuesDragging)
            //{
            //    return;
            //}

            //Vector3 forward = transform.right;
            //Vector3 dragVectorDirection = InputController.Instance.GetMousePosition().normalized;

            //if (Vector3.Dot(forward, dragVectorDirection) < 0)
            //{
            //    UIController.Instance.InstantiateFloatingText();
            //    GameController.Instance.AddPoints(1);
            //    GameController.Instance.AddTears(1);
            //    SetArrowRotation();
            //    background.SetDirection(Trigonometry.angles[0]);
            //}
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
        }

  
        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (GameController.Instance.CurrentStatus != GameController.Status.GameInProgress 
                && continuesDragging )
            {
                return;
            }

            Vector3 forward = transform.right;
            Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;

            if (Vector3.Dot(forward, dragVectorDirection) > 0)
            {
                UIController.Instance.InstantiateFloatingText();
                GameController.Instance.points.Add(1);
                GameController.Instance.AddTears(1);
                GameController.Instance.timer.SetTime(5);
                SetArrowRotation();
                UIController.Instance.diagnal?.SetDirection(Trigonometry.angles[lastRandomIndex]);
                GameController.Instance.onionEntity.animator.Play(Trigonometry.angles[lastRandomIndex].ToString());
                dragEmitter.Play();
            }

        }

        private void SetArrowRotation()
        {
            int currentRandomindex = random.Next(Trigonometry.angles.Count);
            if (currentRandomindex != lastRandomIndex)
            {
                transform.rotation = Quaternion.AngleAxis(Trigonometry.angles[currentRandomindex], Vector3.forward);
                lastRandomIndex = currentRandomindex;
            }
        }

    }
}