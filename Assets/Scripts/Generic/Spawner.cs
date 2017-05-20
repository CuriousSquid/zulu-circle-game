using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

namespace Assets.Scripts.Generic
{
	/**
	 * @class SpawnEvent
	 * @brief Invoked when a GameObject is spawned.
	 */
	[Serializable]
	public class SpawnEvent : UnityEvent<GameObject> {}

	/**
	 * @class Spawner
	 * @brief Basic class to instanciate GameObjects.
	 */
	public class Spawner : MonoBehaviour {

		#region Variables

		[Tooltip("Spawned objects will be instanciated as the child of this object.")]
		[SerializeField] protected GameObject spawnParent;

		[Tooltip("The object to be spawned.")]
		[SerializeField] protected GameObject thingToSpawn;
		
		[Tooltip("Maximum time (in seconds) between spawns.")]
		[SerializeField] protected float minInterval = 1.0f;

		[Tooltip("Minimum time (in seconds) between spawns.")]
		[SerializeField] protected float maxInterval = 2.0f;

		[Tooltip("If checked, only one instance will be spawned.")]
		[SerializeField] protected bool oneShot;

		public SpawnEvent OnSpawn;

		private bool isRunning;
		
		#endregion
		
		#region Unity Methods
		
		[UsedImplicitly]
		private void Start () {
			isRunning = !oneShot;
			StartCoroutine(DoSpawn());
		}
		
		#endregion

		public virtual IEnumerator DoSpawn()
		{
			do
			{
				yield return new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));
				OnSpawn?.Invoke(
					Instantiate(thingToSpawn, transform.position, Quaternion.identity, spawnParent.transform)
				);
				
			} while (isRunning);
		}

		public void Stop()
		{
			isRunning = false;
		}
	}
}
