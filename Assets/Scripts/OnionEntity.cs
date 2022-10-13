using System.Collections;
using UnityEngine;
using UnityEditor;
using Chars.Tools;

namespace Onion
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class OnionEntity : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        public Animator animator;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            GameController.Instance.onionEntity = this;
        }

        private void Start()
        {
        }

        private void Update()
        {
        }


    }

}