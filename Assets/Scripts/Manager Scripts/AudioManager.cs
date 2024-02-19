using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static AudioManager Instance;

    // Flag to allow overlapping sound effects
    public static bool sfxAllowOverlap = false;

    // Audio mixer for managing audio channels
    public AudioMixer Mixer;

    // Arrays of background music and sound effects
    public Sound[] bgm, sfx;

    // Audio sources for background music and sound effects
    public AudioSource bgmSource, sfxSource;

    // Initialize the audio manager
    void Awake()
    {
        Instance = this;
        bgmSource.Stop();
        PlayBGM("Theme");
    }

    // Play a background music track by name
    public void PlayBGM(string name)
    {
        Sound s = Array.Find(bgm, x => x.name == name);
        if (s == null)
        {
            Debug.Log($"Sound '{name}' not found!");
        }
        else
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    // Play a sound effect by name
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        if (s == null)
        {
            Debug.Log($"Sound '{name}' not found!");
        }
        else
        {
            if (!sfxAllowOverlap)
            {
                sfxSource.Stop();
            }
            sfxSource.PlayOneShot(s.clip);
        }
    }

    // Adjust the volume of the background music
    public void BGMVolume(float volume)
    {
        // Ensure volume is not zero to avoid log(0) error
        volume = Mathf.Max(volume, 0.0001f);

        // Convert linear volume to decibels
        float decibels = 20f * Mathf.Log10(volume);

        Mixer.SetFloat("bgmMixerVolume", decibels);
    }

    // Adjust the volume of the sound effects
    public void SFXVolume(float volume)
    {
        // Ensure volume is not zero to avoid log(0) error
        volume = Mathf.Max(volume, 0.0001f);

        // Convert linear volume to decibels
        float decibels = 20f * Mathf.Log10(volume);

        Mixer.SetFloat("sfxMixerVolume", decibels);
    }
}
