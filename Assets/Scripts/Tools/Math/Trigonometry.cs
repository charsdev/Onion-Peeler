using UnityEngine;
using System.Collections.Generic;

namespace Chars.Tools
{
    public class Trigonometry
    {
        public static List<Vector3> directions = new List<Vector3>
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            Vector3.up + Vector3.left,
            Vector3.up + Vector3.right,
            Vector3.down + Vector3.left,
            Vector3.down + Vector3.right
        };

        public static List<int> angles = new List<int> 
        {
            0, 45, 90, 135, 180, 225, 270, 315
        };

        public static Vector3 GetAngleFromDirection(Vector3 direction)
        {
            float minAngle = float.MaxValue;
            Vector3 vector = Vector2.zero;

            for (int i = 0; i < directions.Count; i++)
            {
                Vector3 v = directions[i];
                float angle = Vector3.Angle(direction, vector);
                if (angle < minAngle)
                {
                    minAngle = angle;
                    vector = v;
                }
            }
            return vector;
        }

        public static bool OnRadialTrigger(Vector3 pos, Vector3 to, float radius)
        {
            Vector3 delta = pos - to;
            return delta.x * delta.x + delta.y * delta.y < radius * radius;
        }

        public static Vector3 GetDragFourDirection(Vector3 dragVector)
        {
            float positiveX = Mathf.Abs(dragVector.x);
            float positiveY = Mathf.Abs(dragVector.y);
            Vector3 draggedDir;

            if (positiveX > positiveY)
            {
                draggedDir = (dragVector.x > 0) ? Vector3.right : Vector3.left;
            }
            else
            {
                draggedDir = (dragVector.y > 0) ? Vector3.up : Vector3.down;
            }
            return draggedDir;

        }

        public static Vector3 GetVectorFromAngle(float degrees)
        {
            float radians = degrees * Mathf.PI / 180;
            Vector3 v = new Vector2( Mathf.RoundToInt( Mathf.Cos(radians) ), Mathf.RoundToInt( Mathf.Sin(radians) ) );
            return v;
        }
    }
}