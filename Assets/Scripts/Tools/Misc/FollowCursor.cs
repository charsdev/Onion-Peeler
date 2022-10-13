using System.Collections;
using UnityEngine;

namespace Chars.Tools
{
    public class FollowCursor : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            transform.position = InputHelper.GetMousePosition2D();
        }
    }
}