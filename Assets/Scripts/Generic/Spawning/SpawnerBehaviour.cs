/* Copyright (c) Alex Meuer
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic.Spawning
{
	/*
	 * @class SpawnerBehaviour
	 * @brief
	 */
	public abstract class SpawnerBehaviour : MonoBehaviour {

		#region Variables

		public delegate void SpawnCallback(Vector3 position);
		public SpawnCallback SpawnFunc;

		#endregion

		public abstract void DoSpawn();
	}
}
