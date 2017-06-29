/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Assets.Scripts.Game.Controllers
{
	/*
	 * @class SpawnController
	 * @brief What does this class do?
	 */
	public class SpawnController : MonoBehaviour {

		#region Variables

		[SerializeField]
		private List<Generic.Spawning.SpawnerBehaviour> behaviours;

		private List<GameObject> spawners;
		
		#endregion
		
		#region Unity Methods
		
		[UsedImplicitly]
		private void Start () {
			spawners = new List<GameObject>();
			StartCoroutine(Begin());
		}

		#endregion

		private IEnumerator Begin() {
			yield return new WaitForSeconds(0.0f);

			// Find all spawners.
			spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawner"));
			Debug.Log($"{name}: Found {spawners.Count} spawners.");

			// Remove any GameObject that don't have the Spawner component.
			spawners.RemoveAll(DoesObjectLackSpawnerComponent);

			while (true) {
				yield return new WaitForSeconds(5.0f);
				foreach (GameObject gO in spawners) {
					var spawner = gO.GetComponent<Generic.Spawner>();
					spawner.SpawnBehaviour = Instantiate(behaviours[UnityEngine.Random.Range(0, behaviours.Count)]);
					// TODO: Use an object pool. Avoid repeated instantiation.
				}
			}
		}

		private static bool DoesObjectLackSpawnerComponent(GameObject spawner) {
			bool invalid = null == spawner.GetComponent<Generic.Spawner>();
			if (invalid) {
				Debug.LogWarning($"{spawner.name} is tagged as a Spawner, but lacks the component!");
			}
			return invalid;
		}
	}
}
