/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

// Disable the "Never assigned and will always have default value" warning.
#pragma warning disable 0649

using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Generic
{
	/**
	 * @class HurtOtherOnContact
	 * @brief Hurts GameObjects on contact if their tag is in the list.
	 */
	public class HurtOtherOnContact : MonoBehaviour {

		#region Variables

		[Tooltip("Objects that collide with this will be destroyed if their tag is in this list.")]
		[SerializeField] private List<string> vulnerableTags;

		[Tooltip("The amount of damage to apply to stuff we hit.")]
		[SerializeField] private int damage;

		[Tooltip("How much damage we should take when dealing damage. Requires a Health component.")]
		[SerializeField] [Range(0, 100)] private int recoilPercentage;

		[Tooltip("If true, object without Health components will be destoryed on contact. Otherwise, they will be ignored.")]
		[SerializeField] private bool destroyObjectsWithoutHealth;

        [Tooltip("Fooest of the Bars")]
        [SerializeField] private AudioClip collideSfx;

        private Health ourHealth;

		#endregion

		#region Unity Methods
		[UsedImplicitly]
		private void Start()
		{
			if (0 < recoilPercentage)
			{
				// Can't have recoil damage without a health component!
				ourHealth = GetComponent<Health>();
				if (null == ourHealth)
				{
					recoilPercentage = 0;
					Debug.LogWarning($"{name}: Cannot use recoil without a Health component!", this);
				}
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			checkAndHurt(collision.collider);
		}

		private void OnTriggerEnter2D(Collider2D collider)
		{
			checkAndHurt(collider);
		}

		#endregion
        
		/**
		 * @brief Hurts the other object if it is vulnerable to us.
		 * @param collider The thing we collided with.
		 */
		private void checkAndHurt(Collider2D collider)
		{
			// Is the thing we collided with vulnerable to us?
			if (vulnerableTags.Contains(collider.tag))
			{/*
                if (collideSfx.loadState == AudioDataLoadState.Loaded)
                    AudioSource.PlayClipAtPoint(collideSfx, new Vector3(0, 0, -9));*/
                var colliderHealth = collider.gameObject.GetComponent<Health>();
				// If the thing we collided with doesn't have a Health component...
				if (null == colliderHealth)
				{
					//...then should we destroy it?
					if (destroyObjectsWithoutHealth)
					{
						Destroy(collider.gameObject);
					}
				} else
				{
					// It's vulnerable to us and has a Health component, so we're gonna hurt it!
					colliderHealth.Hurt(damage);

					// Do we hit with recoil?
					if (0 < recoilPercentage)
					{
						ourHealth.Hurt(damage * recoilPercentage);
					}
				}
			}
		}
	}
}
