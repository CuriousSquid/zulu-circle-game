/* Copyright (c) Alex Meuer
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Generic
{
	/*
	 * @class Spawner
	 * @brief Container for a SpawnerBehaviour.
	 */
	public class Spawner : MonoBehaviour {

		#region Variables

		[SerializeField]
		private Spawning.SpawnQueue behaviourQueue;

		private Spawning.SpawnerBehaviour _spawnBehaviour;
		public Spawning.SpawnerBehaviour SpawnBehaviour {
			get { return _spawnBehaviour; }
			set {
				if (null != _spawnBehaviour) {
					_spawnBehaviour.Stop();
				}
				_spawnBehaviour = value;
				_spawnBehaviour.Transform = transform;
				StartCoroutine(_spawnBehaviour.Run());
			}
		}

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		void Start() {
			behaviourQueue.SpawnerObject = gameObject;
			StartCoroutine(behaviourQueue.Run());
		}

		[UsedImplicitly]
		void OnDestroy() {
			_spawnBehaviour.Stop();
		}

		#endregion
	}
}
