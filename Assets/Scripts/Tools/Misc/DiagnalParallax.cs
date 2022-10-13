using UnityEngine;

namespace Chars.Tools
{
	public class DiagnalParallax : MonoBehaviour
	{
		private Material material;
		public float speed = 50f;
		public Vector3 direction;

        private void Start()
        {
			material = GetComponent<Renderer>().material;
			material.shader = Shader.Find("Custom/CG_Offset");
			UpdateShader();
		}

        private void Update()
        {
			UpdateShader();
		}

        private void UpdateShader()
		{
			material.SetFloat("_Horizontal", direction.x);
			material.SetFloat("_Vertical", direction.y);
			material.SetFloat("_Speed", speed);
		}

		public void SetDirection(float angle)
		{
			direction = Trigonometry.GetVectorFromAngle(angle);
		}

		public void SetDirection(Vector3 dir)
		{
			direction = dir;
		}
	}
}
