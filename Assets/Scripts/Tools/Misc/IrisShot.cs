using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chars.Tools {

    public class IrisShot : MonoBehaviour
    {
        [SerializeField] private Texture2D imageAsset;
        [SerializeField] private Shader shader;
        private Texture2D texture2D;
        [SerializeField] private Material material;
        [SerializeField] private float param;
        [SerializeField] private float lit;
        private byte[] bytes;
        [SerializeField] private Vector4 offset = Vector4.zero;

        private void Awake()
        {
            material = new Material(shader);
            texture2D = new Texture2D(2, 2);
            bytes = imageAsset.EncodeToPNG();
            texture2D.LoadImage(bytes);
            texture2D.wrapMode = TextureWrapMode.Clamp;
            material.SetTexture("_tex", texture2D);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            lit = param > 8.0f ? 0 : 1;
            material.SetFloat("_lit", lit);
            material.SetFloat("_aspect", Camera.main.aspect);
            material.SetVector("_offset", offset * param);
            material.SetFloat("_param", param);
            Graphics.Blit(source, destination, material);
        }

        public IEnumerator DoFade() { yield return null; }


      
    }
}

