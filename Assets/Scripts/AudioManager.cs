using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public static void Play(AudioSource audioSource, AudioClip audioClip)
    {
        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
