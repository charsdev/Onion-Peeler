using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Chars.Tools;

namespace Onion
{
    public class MenuController : Singleton<MenuController>
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("MainGameScene");
        }
        
    }
}