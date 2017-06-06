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
     * @class UISoundEFX
     * @brief What does this class do?
     */
    public class UISoundEFX : MonoBehaviour {

        #region Variables
        #pragma warning disable 0168 // variable declared but not used.
        [Tooltip("Add Tool tip!")]
        [SerializeField]
        private AudioClip touch;
        [Tooltip("Add Tool tip!")]
        [SerializeField]
        private AudioClip back;

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

        public AudioClip getTouch() {
            return touch;
        }
        public AudioClip getBack() {
            return back;
        }
    }
}