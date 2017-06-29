using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

namespace Assets.Scripts.Generic.Spawning
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
	public class SpawnerStateEvent : UnityEvent<SpawnerBehaviour> {}

	/**
	 * @class Spawner
	 * @brief Basic class to instanciate GameObjects.
	 */
	public abstract class SpawnerBehaviour : ScriptableObject {


		#region Variables

		public enum State {
			STOPPED,    // Spawner is not running and has not reached max spawn count.
			RUNNING,
			FINISHED    // Spawner has reached max spawn count.
		}
		private State _currentState;
		public State CurrentState {
			get {
				return _currentState;
			}
		}

		[Tooltip("The object to be spawned.")]
		[SerializeField] protected GameObject thingToSpawn;

		[Tooltip("Maximum time (in seconds) between spawns.")]
		[SerializeField] protected float minInterval = 1.0f;

		[Tooltip("Minimum time (in seconds) between spawns.")]
		[SerializeField] protected float maxInterval = 2.0f;

		[Tooltip("Amount of things to spawn (0 = No Limit).")]
		[SerializeField] protected int numberToSpawn;

		protected int spawnCount;   // Number of things spawned so far.

		public SpawnEvent OnSpawn;
		public SpawnerStateEvent OnStateChange;

		public Transform Transform { get; set; }

		private GameObject parent;

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void Awake() {
			spawnCount = 0;
			// If number to spawn is 0, count as max.
			if (0 == numberToSpawn) {
				numberToSpawn = int.MaxValue;
			}
		}
		
		#endregion

		public IEnumerator Run() {
			parent = GameObject.FindGameObjectWithTag("DynamicObjectsContainer");
			SetState(State.RUNNING);
			do
			{
				yield return DoSpawnBehaviour();

				if (spawnCount >= numberToSpawn) {
					Stop();
				}
				
			} while (State.RUNNING == _currentState);
		}

		protected abstract IEnumerator DoSpawnBehaviour();

		protected GameObject Instantiate(GameObject thingToSpawn, Vector3 position, Quaternion rotation) {
			++spawnCount;
			GameObject spawned = UnityEngine.Object.Instantiate(thingToSpawn, position, rotation, parent.transform);
			OnSpawn?.Invoke(spawned);
			return spawned;
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
