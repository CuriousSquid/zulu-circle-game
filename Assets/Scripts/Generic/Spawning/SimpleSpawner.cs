/* Copyright (c) Alex Meuer
 * http://github.com/CuriousSquid
 */

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic.Spawning
{
	/*
	 * @class SimpleSpawner
	 * @brief Spawns a thing at the current transform position.
	 */
	public class SimpleSpawner : SpawnerBehaviour {

		public override void DoSpawn() {
			SpawnFunc(transform.position);
		}
	}
}
