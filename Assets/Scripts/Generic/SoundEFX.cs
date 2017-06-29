/* 
 * Copyright (c) Josh Mooney
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Generic
{
    /*
     * @class SoundEFX
     * @brief Plays sounds based on health events.
     */
	 [RequireComponent(typeof(Health))]
    public class SoundEFX : MonoBehaviour {

		#region Variables
		#pragma warning disable 0168 // variable declared but not used.
		#pragma warning disable 0649 // variable not assigned
		[Tooltip("Clip played when hte object spawns.")]
        [SerializeField]
        private AudioClip spawn;
        [Tooltip("Clip played when the object is hurt.")]
        [SerializeField]
        private AudioClip hurt;
        [Tooltip("Clip played when the object dies.")]
        [SerializeField]
        private AudioClip die;

        #endregion

        public bool hasSound(AudioClip clip) {
            return (clip == null) ? false : isLoaded(clip);
        }
        private bool isLoaded(AudioClip clip) {
            return clip.loadState == AudioDataLoadState.Loaded;
        }

        public AudioClip getSpawn() {
            return spawn;
        }
        public AudioClip getDie() {
            return die;
        }
        public AudioClip getHurt() {
            return hurt;
        }
    }
}