/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Generic
{
	/*
	 * @class RandomColor
	 * @brief Tints the sprite a random color on start.
	 * 
	 * Will also set the start color of attached particle system if present.
	 */
	 [RequireComponent(typeof(SpriteRenderer))]
	public class RandomColor : MonoBehaviour {

		private SpriteRenderer sprite;
		private ParticleSystem particles;
		
		#region Unity Methods
		
		[UsedImplicitly]
		private void Start () {
			sprite = GetComponent<SpriteRenderer>();
			particles = GetComponent<ParticleSystem>();
            if (null == particles)
            {
                particles = GetComponentInChildren<ParticleSystem>();
            }
			RandomizeColour();
		}
		
		#endregion

		public void RandomizeColour()
		{
			sprite.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
			if (null != particles)
			{
				particles.startColor = sprite.color;
			}
		}
	}
}
