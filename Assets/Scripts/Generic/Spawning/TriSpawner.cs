using System;
using System.Collections;
/* Copyright (c) Alex Meuer
* http://github.com/CuriousSquid
*/

using UnityEngine;

namespace Assets.Scripts.Generic.Spawning {

	public class TriSpawner : SpawnerBehaviour {
		protected override IEnumerator DoSpawnBehaviour() {
			yield return new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));
			Instantiate(thingToSpawn, Transform.position, Transform.rotation);
			Instantiate(thingToSpawn, Transform.position, Transform.rotation);
			Instantiate(thingToSpawn, Transform.position, Transform.rotation);
		}
	}
}
