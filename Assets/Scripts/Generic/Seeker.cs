// Disable the "Never assigned and will always have default value" warning.
#pragma warning disable 0649

using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic
{
	/**
	 * @class Seeker
	 * @brief Travels toward a specified target.
	 */
	[RequireComponent(typeof(Rigidbody2D))]
	public class Seeker : MonoBehaviour {

		#region Variables

		[Tooltip("The object that we will travel toward.")]
		[SerializeField] private GameObject target;

		[Tooltip("How fast we turn (in radians).")]
		[SerializeField] private float rotateSpeed = 5.0f;

		[Tooltip("How fast we move forward.")]
		[SerializeField] private float acceleration = 50.0f;

		[SerializeField] private float maxMoveSpeed = 3.0f;

		private new Rigidbody2D rigidbody;

		private Vector2 direction;

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void Start()
		{
			rigidbody = GetComponent<Rigidbody2D>();
			direction = Vector2.up;
		}

		[UsedImplicitly]
		private void FixedUpdate() {
			//var targetDisplacement = target.transform.position - transform.position;

			//transform.rotation = Quaternion.Slerp(
			//	transform.rotation,
			//	Quaternion.LookRotation(Vector3.forward, targetDisplacement),
			//	rotateSpeed * Time.fixedDeltaTime
			//	);

			//rigidbody.AddForce(transform.up, ForceMode2D.Force);
			//if (maxMoveSpeed < rigidbody.velocity.magnitude) {
			//	rigidbody.velocity = rigidbody.velocity.normalized * maxMoveSpeed;
			//}

			float delta = AngleBetweenVector2(transform.right, target.transform.position - transform.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(delta, Vector3.forward), rotateSpeed);

			rigidbody.AddForce(transform.right);
			rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxMoveSpeed);

			Debug.DrawRay(transform.position, rigidbody.velocity, Color.white);
			Debug.DrawRay(transform.position, transform.right, Color.yellow);
		}

		#endregion

		private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
		{
			Vector2 diference = vec2 - vec1;
			float sign = (vec2.x < vec1.x) ? -1.0f : 1.0f;
			return Vector2.Angle(Vector2.right, diference) * sign;
		}
	}
}
