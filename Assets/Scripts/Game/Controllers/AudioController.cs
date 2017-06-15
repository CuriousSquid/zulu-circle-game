/* 
 * Copyright (c) Josh Mooney
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	#region Variables
	#pragma warning disable 0649 // variable not assigned
	[Tooltip("The audio source which will play the sound effects.")]
    [SerializeField] private AudioSource efxSource;         //Drag a reference to the audio source which will play the sound effects.
    [Tooltip("The audio source that will play the game music.")]
    [SerializeField] private AudioSource musicSource;       //Drag a reference to the audio source which will play the music.
    public static AudioController instance = null;          //Allows other scripts to call functions from SoundManager.             
    private float lowPitchRange = .95f;                     //The lowest a sound effect will be randomly pitched.
    private float highPitchRange = 1.05f;                   //The highest a sound effect will be randomly pitched.

    #endregion

    #region Unity Methods

    [UsedImplicitly]
    private void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
        
    #endregion

    /**
        * @brief Plays and pitches a single instance of the AudioClip passed in.
        * @param clip The AudioClip passed in to be played. 
        */
    public void PlaySingle(AudioClip clip) {
        efxSource.pitch = getRandomPitch();
        efxSource.clip = clip;
        efxSource.Play();
    }

    /**
        * @brief Randomly picks an audio clip from the clips array, pitches and plays it.
        * @param clips An array of AudioClips
        */
    public void RandomizeSfx(params AudioClip[] clips) {
        int randomIndex = Random.Range(0, clips.Length);
            
        efxSource.pitch = getRandomPitch();
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }

    /**
        * @brief Gets a random pitch using the local variables lowPitchRange and highPitchRange.
        */
    private float getRandomPitch() {
        return Random.Range(lowPitchRange, highPitchRange);
    }
}