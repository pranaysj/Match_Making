using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundService : MonoBehaviour
{
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        PlaybackgroundMusic(SoundType.BACKGROUND_MUSIC);
    }

    public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
    {
        AudioClip clip = GetSoundClip(soundType);
        if (clip != null)
        {
            audioEffects.loop = loopSound;
            audioEffects.clip = clip;
            audioEffects.PlayOneShot(clip);
        }
        else
            Debug.LogError("No Audio Clip selected.");
    }

    private void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
    {
        AudioClip clip = GetSoundClip(soundType);
        if (clip != null)
        {
            backgroundMusic.loop = loopSound;
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
        else
            Debug.LogError("No Audio Clip selected.");
    }

    private AudioClip GetSoundClip(SoundType soundType)
    {
        Sounds sound = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);
        if (sound.audio != null)
            return sound.audio;
        return null;
    }
}
