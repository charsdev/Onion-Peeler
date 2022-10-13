using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Chars.Tools;

namespace Onion
{
    public class SceneTransition : MonoBehaviour
    {
        public CircleWipeController wipeCircle;

        public void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
        {
            wipeCircle.FadeIn();
        }

        private IEnumerator ChangeLevelCO(int scene)
        {
            yield return StartCoroutine(wipeCircle.FadeOutCO());
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        public void ChangeLevel(int scene)
        {
            StartCoroutine(ChangeLevelCO(scene));
        }

    }
}