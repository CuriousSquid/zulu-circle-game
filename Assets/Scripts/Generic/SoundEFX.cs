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
     * @brief What does this class do?
     */
    public class SoundEFX : MonoBehaviour {

        #region Variables
        [Tooltip("Add Tool tip!")]
        [SerializeField][UsedImplicitly]
        private AudioClip spawn;
        [Tooltip("Add Tool tip!")]
        [SerializeField][UsedImplicitly]
        private AudioClip hurt;
        [Tooltip("Add Tool tip!")]
        [SerializeField][UsedImplicitly]
        private AudioClip die;

        #endregion

        #region Unity Methods

        [UsedImplicitly]
        private void Start () {
            
        }
        
        [UsedImplicitly]
        private void Update () {
            
        }
        
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