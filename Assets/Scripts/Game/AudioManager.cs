using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] MusicSounds, SfxSounds;
    public AudioSource MusicSource, SfxSource;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex !=5)
        {
            PlayMusic("Theme");
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(MusicSounds, x => x.Name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            MusicSource.clip = sound.Clip;
            MusicSource.volume = sound.volume;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(SfxSounds, x => x.Name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            SfxSource.PlayOneShot(sound.Clip,sound.volume);
        }
    }
}
