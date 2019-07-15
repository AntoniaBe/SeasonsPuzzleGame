using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SeasonObjectBehaviour
{
    public AudioClip springClip;
    public AudioClip summerClip;
    public AudioClip autumnClip;
    public AudioClip winterClip;
    public AudioSource audioSource;
    public AudioSource swipeTransition;
    public AudioSource riverAudioSource;
    public AudioSource successClipAudioSource;
    private float riverVolume;
    private float ambienceVolume;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        swipeTransition.Play();
        riverAudioSource.volume = 0.2f;
        audioSource.volume = 1f;

        switch (currentSeason)
        {
            case Season.SPRING:
                audioSource.clip = springClip;
                break;
            case Season.SUMMER:
                audioSource.clip = summerClip;
                audioSource.volume = 0.8f;
                break;
            case Season.AUTUMN:
                audioSource.clip = autumnClip;
                break;
            case Season.WINTER:
                audioSource.clip = winterClip;
                riverAudioSource.volume = 0;
                break;
        }

        audioSource.Play();
    }

    public void PlaySuccessClip()
    {
        successClipAudioSource.Play();
    }
}
