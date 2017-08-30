/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Generic
{
	/**
	 * @class LeftRightControlManager
	 * @brief When the user touches (or stops touching) the screen, invokes an event with the side touched.
	 */
	public class LeftRightControlManager : MonoBehaviour {
		public enum Side {
			Left,
			Right,
			None
		}

		/**
		 * @class LeftRightInputEvent
		 * @brief Editor-friendly input event.
		 */
		[System.Serializable]
		public class LeftRightInputEvent : UnityEvent<Side> { }

		#region Variables

		//! Invoked then the side of the screen being touched changes (or stops altogether).
		[SerializeField] [UsedImplicitly] public LeftRightInputEvent OnInputChanged;

		//! Current side being touched.
		private Side _currentSide;
		private readonly float _halfScreenWidth = Screen.width * 0.5f;

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void Start () {
			_currentSide = Side.None;
		}
		
		/**
		 * @brief Checks for input and invokes the event as necessary.  
		 * @remarks Only invokes the event if the side has changed.
		 */
		[UsedImplicitly]
		private void Update () {
			var newSide = Side.None;
			if (Input.GetMouseButton(0)) {
				// Which side of the screen is the input on?
				newSide = Input.mousePosition.x < _halfScreenWidth
					? Side.Left
					: Side.Right;
			}

			// Do nothing if the side has not changed.
			if (newSide == _currentSide) {
				return;
			}

			// Update the side and invoke the event.
			_currentSide = newSide;
			OnInputChanged.Invoke(_currentSide);
		}
		
		#endregion
	}
}
