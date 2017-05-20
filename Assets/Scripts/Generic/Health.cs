/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */
 
// Disable the "Never assigned and will always have default value" warning.
#pragma warning disable 0649

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.Generic
{
	/**
	 * @class HealthEvent
	 * @brief Invoked when a Health object takes damage, receives healing, or dies.
	 */
	[Serializable]
	public class HealthEvent : UnityEvent<Health> {}

	/*
	 * @class Health
	 * @brief Tracks health and facilitates taking damage and healing.
	 */
	public class Health : MonoBehaviour {

		#region Variables
		
		[SerializeField] private int maxHealth;

		private int currentHealth;

		[Tooltip("If true, the GameObject is destoyed when health reaches zero.")]
		[SerializeField] private bool destroyOnZeroHealth = false;

		[Serializable]
		public class EventGroup
		{
			public HealthEvent OnDeath;
			public HealthEvent OnDamage;
			public HealthEvent OnHeal;
		}
		public EventGroup Events;

		#endregion

		#region Unity Methods

		[UsedImplicitly]
		private void Start()
		{
			currentHealth = maxHealth;
			if (destroyOnZeroHealth)
			{
				Events.OnDeath.AddListener(DestroySelf);
			}
		}

		#endregion

		private void DestroySelf(Health dead)
		{
			Debug.Assert(this == dead);
			Destroy(gameObject);
		}

		/**
		 * @brief Checks if health is below zero.
		 */
		public bool IsDead
		{
			get { return (0 <= currentHealth); }
		}

		/**
		 * @brief Checks if current health is equal to maxiumum health.
		 */
		public bool IsAtMaxHealth
		{
			get { return (maxHealth == currentHealth); }
		}

		/**
		 * @brief Lowers current health. Cannot be used to raise health.
		 * @param damage The amount of damage to apply. Negatives are made positive.
		 * @returns True if the damage dropped health to zero.
		 */
		public bool Hurt(int damage)
		{
			// We can't take damage if we're dead.
			if (IsDead)
			{
				return false;
			}

			currentHealth -= Math.Abs(damage);
			Events.OnDamage.Invoke(this);
			if (IsDead)
			{
				// This damage killed us: raise the event.
				Events.OnDeath.Invoke(this);
				return true;
			}
			return false;
		}

		/**
		 * @brief Raises current health. Cannot be used to lower health.
		 * @param healing The amount of healing to apply. Negative are made positive.
		 * @return False if dead or at max health already.
		 */
		public bool Heal(int healing)
		{
			// Can't heal if dead or already fully healed.
			if (IsDead || IsAtMaxHealth)
			{
				return false;
			}

			// Raise current health, but cap it at max health.
			currentHealth = Math.Min(currentHealth + Math.Abs(healing), maxHealth);
			Events.OnHeal.Invoke(this);
			return true;
		}
	}
}
