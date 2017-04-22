/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic
{
	/*
	 * @class SetupNestedPrefabs
	 * @brief Allows nesting of prefabs to be instanciated on start.
	 */
	public class SetupNestedPrefabs : MonoBehaviour {

		/*
		 * @class NestableGameObject
		 * @brief Representation of a nested prefab or game object.
		 */
		[System.Serializable]
		public class NestableGameObject
		{
			[SerializeField] [UsedImplicitly] public GameObject Prefab;
			[SerializeField] [UsedImplicitly] public List<GameObject> Children;
		}

		#region Variables

		[Tooltip("The root under which the nested objects will be created.")]
		[SerializeField] [CanBeNull] private GameObject Root;

		[SerializeField] private List<NestableGameObject> Objects;
		
		#endregion
		
		#region Unity Methods
		
		[UsedImplicitly]
		private void Start () {
			var rootTransform = (null == Root) ? gameObject.transform.parent : Root.transform;
			Debug.Log($"[{name}]Beginning nested prefab instantiation...", gameObject);
			foreach (var nestable in Objects) {
				var parent = Instantiate(nestable.Prefab, rootTransform);
				parent.SetActive(true);
				foreach (var child in nestable.Children) {
					Instantiate(child, parent.transform)
						.SetActive(true);
				}
			}
			Debug.Log($"[{name}]Finished nested prefab instantiation. Self-destructing.", gameObject);
			Destroy(this.gameObject);
		}
		
		[UsedImplicitly]
		private void Update () {
			
		}
		
		#endregion
	}
}
