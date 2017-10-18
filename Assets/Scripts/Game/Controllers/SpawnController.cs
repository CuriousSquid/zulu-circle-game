/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Assets.Scripts.Generic;

namespace Assets.Scripts.Game.Controllers
{
	/*
	 * @class SpawnController
	 * @brief 
	 */
	public class SpawnController : MonoBehaviour {

		[Serializable]
		public class SpawnerArgs {
			[Tooltip("The spawner object to instanciate (Invalid gameObjects will be ignored).")]
			public GameObject spawnerPrefab;
			[Tooltip("The position at which to instanciate the prefab.")]
			public Vector3 spawnPosition;
			[Tooltip("How long, in seconds, before the instanciated spawner is destroyed (0 == forever).")]
			public int timeToLive;
			[Tooltip("How long, in seconds, to wait before instanciating the prefab.")]
			public int delay;
		}

		#region Variables

		[SerializeField]
		private List<SpawnerArgs> spawnerQueue;

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void OnEnable() {
			StartCoroutine(Run());
		}

		[UsedImplicitly]
		private void OnDisable() {
			StopAllCoroutines();
			DestroyAllChildren();
		}

		#endregion

		private IEnumerator Run() {
			foreach (SpawnerArgs entry in spawnerQueue) {
				if(null == entry.spawnerPrefab?.GetComponent<Spawner>()) {
					// Remove the entry if the prefab is not a spawner
					Debug.LogWarning($"{name}: A SpawnerArgs item has a non-spawner prefab assigned! (Ignoring)");
					spawnerQueue.Remove(entry);
				} else {
					yield return new WaitForSeconds(entry.delay);
					// Create the new object as our child.
					GameObject newSpawner = Instantiate(entry.spawnerPrefab, entry.spawnPosition, Quaternion.identity, transform);

					if (0 < entry.timeToLive) {
						// Destroy at end of lifetime
						Destroy(newSpawner, entry.timeToLive);
					}

				}
			}
		}

		private void DestroyAllChildren() {
			for (int i = transform.childCount - 1; i >= 0; i--) {
				Destroy(transform.GetChild(i).gameObject);
			}
		}
	}
}
