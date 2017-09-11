using UnityEngine;
using UnityEditor;
using Assets.Scripts.Generic.Spawning;

public class SpawnerQueueAsset {
	[MenuItem("Assets/Create/Spawning/Queue")]
	public static void CreateSpawnQueue() {
		ScriptableObjectUtility.CreateAsset<SpawnQueue>();
	}
}