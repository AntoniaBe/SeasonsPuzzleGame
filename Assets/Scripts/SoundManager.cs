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
    public AudioSource riverAudioSource;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        riverAudioSource.volume = 0.1f;

        switch (currentSeason)
        {
            case Season.SPRING:
                audioSource.clip = springClip;
                break;
            case Season.SUMMER:
                audioSource.clip = summerClip;
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
}
