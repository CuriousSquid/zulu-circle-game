/* Copyright (c) Alex Meuer
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Generic.Spawning
{
	/*
	 * @class SpawnQueue
	 * @brief What does this class do?
	 */
	public class SpawnQueue : ScriptableObject {

		[Serializable]
		private class SpawnEntry {
			[SerializeField]
			[Tooltip("The behaviour to apply to the spawner.")]
			private SpawnerBehaviour behaviour;
			[SerializeField]
			[Tooltip("How long, in seconds, to wait before applying next behaviour.")]
			private float duration;

			public SpawnerBehaviour Behaviour => behaviour;

			public IEnumerator WaitForDuration() {
				yield return new WaitForSeconds(duration);
			}
		}

		#region Variables

		[SerializeField][Tooltip("The queue of behaviours to apply to the spawner. Use empty behaviors as wait durations.")]
		private List<SpawnEntry> queue;

		public GameObject SpawnerObject { get; set; }

		[SerializeField][Tooltip("If the queue should start again when it reaches the end.")]
		private bool loop = true;

		private bool isRunning;

		#endregion

		public IEnumerator Run() {
			Spawner spawner = SpawnerObject.GetComponent<Spawner>();
			
			if (CheckForErrors(spawner)) {
				yield break;
			}

			isRunning = true;

			do {

				foreach (SpawnEntry entry in queue) {
					if (null != entry.Behaviour) {
						SpawnerBehaviour old = entry.Behaviour;
						spawner.SpawnBehaviour = Instantiate(entry.Behaviour);
						if (old.name.Contains("Clone")) {
							DestroyImmediate(old, true);
						}
					}

					if (isRunning) {
						yield return entry.WaitForDuration();
					} else {
						yield break;
					}
				}
			} while (loop);
			isRunning = false;
		}

		public void Stop() {
			isRunning = false;
		}

		private bool CheckForErrors(Spawner spawnerComponent) {
			bool errorWasFound = false;
			
			if (null == spawnerComponent) {
				Debug.LogError($"{name}: Invalid spawner!");
				errorWasFound = true;
			}

			if (isRunning) {
				Debug.LogWarning($"{name}: Aleady running! Call Stop() first if you want to restart.");
			}

			if (queue.Count == 0) {
				Debug.LogError($"{name}: Empty behaviour queue!");
				errorWasFound = true;
			}

			return errorWasFound;
		}
	}
}
