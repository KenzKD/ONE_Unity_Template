using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public static bool sfxAllowOverlap = false;
    public AudioMixer Mixer;
    public Sound[] bgm, sfx;
    public AudioSource bgmSource, sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        bgmSource.Stop();
        PlayBGM("Theme");
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(bgm, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
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

    public void BGMVolume(float volume)
    {
        if (volume == 0)
        {
            volume = 0.0001f;
        }
        float decibels = Mathf.Log10(volume) * 20f;
        Mixer.SetFloat("bgmMixerVolume", decibels);
    }

    public void SFXVolume(float volume)
    {
        if (volume == 0)
        {
            volume = 0.0001f;
        }
        float decibels = Mathf.Log10(volume) * 20f;
        Mixer.SetFloat("sfxMixerVolume", Mathf.Log10(volume) * 20f);
    }
}
