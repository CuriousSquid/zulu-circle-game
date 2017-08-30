using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Generic
{
	[Serializable]
	public class Wave {
		[Tooltip("What to spawn for this wave and how many of each thing.")]
		public List<KeyValuePair<int, GameObject>> thingsToSpawn;

		[SerializeField]
		private float delay;

		//public float Delay => delay;
	}
}
