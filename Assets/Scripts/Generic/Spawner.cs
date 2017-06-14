/* Copyright (c) Alex Meuer
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic
{
	/*
	 * @class Spawner
	 * @brief Container for a SpawnerBehaviour.
	 */
	public class Spawner : MonoBehaviour {

		#region Variables

		[SerializeField]
		private Spawning.SpawnerBehaviour _spawnBehaviour;
		public Spawning.SpawnerBehaviour SpawnBehaviour {
			set {
				_spawnBehaviour.Stop();
				_spawnBehaviour = value;
				_spawnBehaviour.Transform = transform;
				StartCoroutine(_spawnBehaviour.Run());
			}
		}

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		void Start() {
			_spawnBehaviour.Transform = transform;
			StartCoroutine(_spawnBehaviour.Run());
		}

		[UsedImplicitly]
		void OnDestroy() {
			_spawnBehaviour.Stop();
		}

		#endregion
	}
}
