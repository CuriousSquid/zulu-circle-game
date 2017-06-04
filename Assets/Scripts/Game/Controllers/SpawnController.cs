/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Game.Controllers
{
	/*
	 * @class SpawnController
	 * @brief What does this class do?
	 */
	public class SpawnController : MonoBehaviour {

		#region Variables

		[SerializeField]
		private List<Generic.Spawner> teqwe;
		
		#endregion
		
		#region Unity Methods
		
		[UsedImplicitly]
		private void Start () {
			
		}
		
		[UsedImplicitly]
		private void Update () {
			
		}
		
		#endregion
	}
}
