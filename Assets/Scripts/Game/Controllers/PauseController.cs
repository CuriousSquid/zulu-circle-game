/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Controllers
{
	/*
	 * @class PauseController
	 * @brief Facilitates pausing and resuming the game.
	 */
	public class PauseController : MonoBehaviour {

		/**
		 * @class PauseEvent
		 * @brief Event for when the pause state changes. Arg is the current pause state.
		 */
		[Serializable]
		public class PauseEvent : UnityEvent<bool> { }

		#region Variables

		private bool isCurrentlyPaused;

		public PauseEvent OnPauseChanged;
		
		#endregion

		public bool IsPaused
		{
			get { return isCurrentlyPaused; }
			set
			{
				if (IsPaused != value)
				{
					isCurrentlyPaused = value;
					Time.timeScale = IsPaused ? 0 : 1;
					OnPauseChanged?.Invoke(IsPaused);
				}
			}
		}

		public void Pause()
		{
			IsPaused = true;
		}

		public void Unpause()
		{
			IsPaused = false;
		}

		public void TogglePause()
		{
			IsPaused = !IsPaused;
		}
	}
}
