using System.Collections;
using UnityEngine;

namespace Chars.Tools
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
       
        public static T Instance
        {
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();
					if (instance == null)
					{
						GameObject obj = new GameObject();
						instance = obj.AddComponent<T>();
					}
				}
				return instance;
			}
		}

		protected virtual void Awake()
		{
			if (!Application.isPlaying)
			{
				return;
			}

			instance = this as T;
		}
	}
}