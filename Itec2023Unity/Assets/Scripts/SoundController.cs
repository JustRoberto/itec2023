using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {
        if (sounds != null && sounds.Length > 0)
        {
            int index = Random.Range(0, sounds.Length);
            source.clip = sounds[index];
            source.Play();
        }
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }

    // Attach this method to a UI button click event to play a random sound when the button is clicked
    public void PlaySoundOnClick()
    {
        PlayRandomSound();
    }
}
