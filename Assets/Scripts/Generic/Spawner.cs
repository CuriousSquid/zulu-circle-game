using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

namespace Assets.Scripts.Generic
{
	/**
	 * @class SpawnEvent
	 * @brief Invoked when something is spawned.
	 */
	[Serializable]
	public class SpawnEvent : UnityEvent<GameObject> {}

	/**
	 * @class SpawnerStateEvent
	 * @brief Invoked when Spawner changes state.
	 */
	[Serializable]
	public class SpawnerStateEvent : UnityEvent<Spawner> {}

	/**
	 * @class Spawner
	 * @brief Basic class to instanciate GameObjects.
	 */
	public class Spawner : MonoBehaviour {
		

		#region Variables

		public enum State
		{
			STOPPED,	// Spawner is not running and has not reached max spawn count.
			RUNNING,
			FINISHED	// Spawner has reached max spawn count.
		}
		private State _currentState;
		public State CurrentState {
			get
			{
				return _currentState;
			}
		}

		[Tooltip("Spawned objects will be instanciated as the child of this object.")]
		[SerializeField] protected GameObject spawnParent;

		[Tooltip("The object to be spawned.")]
		[SerializeField] protected GameObject thingToSpawn;
		
		[Tooltip("Maximum time (in seconds) between spawns.")]
		[SerializeField] protected float minInterval = 1.0f;

		[Tooltip("Minimum time (in seconds) between spawns.")]
		[SerializeField] protected float maxInterval = 2.0f;

		[Tooltip("Amount of things to spawn (0 = No Limit).")]
		[SerializeField] protected int numberToSpawn;

		protected int spawnCount;	// Number of things spawned so far.

		public SpawnEvent OnSpawn;
		public SpawnerStateEvent OnStateChange;

		private Spawning.SpawnerBehaviour _spawnerBehaviour;
		public Spawning.SpawnerBehaviour SpawnBehaviour {
			get {
				return _spawnerBehaviour;
			}
			set {
				_spawnerBehaviour = value;
				_spawnerBehaviour.SpawnFunc = SpawnThing;
			}
		}

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void Start () {
			spawnCount = 0;
			// If number to spawn is 0, count as max.
			if (0 == numberToSpawn) {
				numberToSpawn = int.MaxValue;
			}

			// Get and set the spawn behaviour.
			var behaviour = GetComponent<Spawning.SpawnerBehaviour>();
			if (null == behaviour) {
				Debug.LogError($"{name}: No SpawnerBehaviour attached!", gameObject);
			} else {
				SpawnBehaviour = behaviour;
			}

			StartCoroutine(Run());
		}
		
		#endregion

		public IEnumerator Run() {
			SetState(State.RUNNING);
			do
			{
				yield return new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));

				SpawnBehaviour.DoSpawn();

				if (spawnCount >= numberToSpawn) {
					Stop();
				}
				
			} while (State.RUNNING == _currentState);
		}

		protected void SpawnThing(Vector3 position) {
			++spawnCount;
			OnSpawn?.Invoke(
					Instantiate(thingToSpawn, position, Quaternion.identity, spawnParent.transform)
				);
		}

		/**
		 * @brief Sets the state to FINISHED or STOPPED based on whether the desired number of things were spawned.
		 */
		public void Stop() {
			SetState( spawnCount >= numberToSpawn ? State.FINISHED : State.STOPPED );
		}

		/**
		 * @brief Updates the current state and invokes the event.
		 * @param newState The state to set.
		 */
		private void SetState(State newState) {
			if (_currentState != newState) {
				_currentState = newState;
				OnStateChange?.Invoke(this);
			}
		}
	}
}
