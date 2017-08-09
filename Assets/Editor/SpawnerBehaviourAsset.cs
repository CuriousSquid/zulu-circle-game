using UnityEngine;
using UnityEditor;
using Assets.Scripts.Generic.Spawning;

public class SpawnerBehaviourAsset {
	[MenuItem("Assets/Create/SpawnerBehaviour/Simple")]
	public static void CreateSimpleSpawner() {
		ScriptableObjectUtility.CreateAsset<SimpleSpawner>();
	}

	[MenuItem("Assets/Create/SpawnerBehaviour/Tri")]
	public static void CreateTriSpawner() {
		ScriptableObjectUtility.CreateAsset<TriSpawner>();
	}

    [MenuItem("Assets/Create/SpawnerBehaviour/Line")]
    public static void CreateLineSpawner()
    {
        ScriptableObjectUtility.CreateAsset<LineSpawner>();
    }
}