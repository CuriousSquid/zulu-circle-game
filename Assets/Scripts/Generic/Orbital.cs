/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic
{
    /**
     * @class Orbital
     * @brief Moves clockwise or counterclockwise around its parent.  
     * Moves around Vector3.forward if it has no parent.
     */
    public class Orbital : MonoBehaviour, ILeftRightInputListener {

		[System.Serializable]
		private enum RotationDirection
        {
            None = 0,
            Clockwise = -1,
            CounterClockwise = 1
        }

        #region Variables

		//! The current direction of rotation.
        [SerializeField] private RotationDirection direction;
        [SerializeField] private float speed = 1.0f;
		//! The point about which we rotate.
        private Vector3 _origin;

        #endregion

        #region Unity Methods

		/**
		 * @brief Sets the origin of rotation to the parent, if we have one.
		 */
        [UsedImplicitly]
        private void Start ()
        {
            _origin = (null == transform.parent) ? Vector3.forward : transform.parent.position;
        }

		/**
		 * @brief Executes the rotation around the origin.
		 */
        [UsedImplicitly]
        private void Update () {
			// TODO: Make the hardcoded 10.0f a global constant and use for all speed calculations for uniformity.
		    transform.RotateAround(_origin, Vector3.forward, 10.0f * speed * (float)direction * Time.deltaTime);
		}

		#endregion

		/**
		 * @brief Sets the rotation direction based on the side of the screen being touched.
		 * @see LeftRightControlManager
		 */
	    [UsedImplicitly]
	    public void OnLeftRightInput(LeftRightControlManager.Side side) {
		    switch (side) {
			    case LeftRightControlManager.Side.Left:
					direction = RotationDirection.CounterClockwise;
				    break;
			    case LeftRightControlManager.Side.Right:
					direction = RotationDirection.Clockwise;
				    break;
			    case LeftRightControlManager.Side.None:
					direction = RotationDirection.None;
				    break;
			    default:
				    throw new ArgumentOutOfRangeException(nameof(side), side, null);
		    }
	    }
    }
}
