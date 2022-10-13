using UnityEngine;
using Chars.Tools;

namespace Chars.Tools
{
    public static class InputHelper
    {
        public static Vector3 GetMousePosition2D()
        {
            return Camera.main.ScreenToWorldPoint
            (
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)
            );
        }
    }
}