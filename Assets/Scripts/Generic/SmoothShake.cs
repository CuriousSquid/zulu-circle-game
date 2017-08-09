using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Generic {

	/**
	 * @class SmoothShake
	 * @brief Applies a shaking motion to the attached object.
	 */
	public class SmoothShake : MonoBehaviour {

		#region Variables

		[SerializeField]
		private Vector2 offset;
		[SerializeField]
		private Vector2 scrollSpeed;
		[SerializeField]
		private float amplitude = 1;

		private Vector3 oldPos;

		#endregion

		#region Unity Methods

		void Start() {
			oldPos = transform.position;
		}

		// Update is called once per frame
		void Update() {
			var newPos = new Vector3(Mathf.PerlinNoise(offset.x, 0) - 0.5f, Mathf.PerlinNoise(0, offset.y) - 0.5f, 0) * amplitude;
			transform.position = oldPos + newPos;
			offset += scrollSpeed * Time.deltaTime;
		}

		#endregion
	}
}
