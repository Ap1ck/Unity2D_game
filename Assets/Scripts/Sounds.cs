using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Packages
{
    public class Sounds : MonoBehaviour
    {
        public AudioClip[] Sound;

        private AudioSource _audioSours => GetComponent<AudioSource>();

        public void PlaySound(AudioClip clip, float volume = 0.2f, bool destroyed = false, float p1 = 1f, float p2 = 1.2f)
        {
            _audioSours.PlayOneShot(clip, volume);
        }

        public void SelectSound(int number)
        {
            foreach (var s in Sound)
            {
                PlaySound(Sound[number]);
            }
        }

        private void OnEnable()
        {
            PlayerMovement.isMove += SelectSound;
        }

        private void OnDisable()
        {
            PlayerMovement.isMove -= SelectSound;
        }
    }
}
