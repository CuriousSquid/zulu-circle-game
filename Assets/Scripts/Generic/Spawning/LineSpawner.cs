using System;
using System.Collections;
/* Copyright (c) Alex Meuer
* http://github.com/CuriousSquid
*/

using UnityEngine;

namespace Assets.Scripts.Generic.Spawning
{

    public class LineSpawner : SpawnerBehaviour
    {
        [SerializeField][Tooltip("The quantity of things to spawn in quick succession before waiting.")]
        private int numberPerLine = 5;

        [SerializeField][Tooltip("The amount of time between spawning things in the same line.")]
        private float interThingDelay = 0.1f;

        protected override IEnumerator DoSpawnBehaviour()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));
            for (int i = 0; i < numberPerLine; ++i)
            {
                yield return new WaitForSeconds(interThingDelay);
                Instantiate(thingToSpawn, Transform.position, Transform.rotation);
            }
        }
    }
}
