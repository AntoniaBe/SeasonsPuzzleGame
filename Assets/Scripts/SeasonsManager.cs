using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

[System.Serializable]
public class SeasonEvent : UnityEvent<Season>
{
}

public class SeasonsManager : Singleton<SeasonsManager>
{
    public UnityEvent<Season> UpdateSeasonEvent;
    private Season currentSeason;
    private Season[] seasons;
    private int currentSeasonIndex;
    private Season lastSeason;

    private void Awake()
    {
        UpdateSeasonEvent = new SeasonEvent();
        seasons = new Season[4] {Season.SPRING, Season.SUMMER, Season.FALL, Season.WINTER};
        currentSeasonIndex = 0;
    }

    private void Start()
    {

    }

    public Season ChangeSeasonForwards() 
    {
        lastSeason = currentSeason;
        currentSeasonIndex++;
        if (currentSeasonIndex >= seasons.Length)
        {
            currentSeasonIndex = 0;
        }
        
        return currentSeason;
    }

    public Season ChangeSeasonBackwards()
    {
        lastSeason = currentSeason;
        currentSeasonIndex--;
        if (currentSeasonIndex < 0)
        {
            currentSeasonIndex = seasons.Length - 1;
        }
        return currentSeason;
    }

    public void TriggerUpdateSeasonEvent()
    {
        UpdateSeasonEvent.Invoke(currentSeason);
    }

    public Season GetLastSeason()
    {
        return lastSeason;
    }

    public Season GetCurrentSeason()
    {
        return seasons[currentSeasonIndex];

    }

    public void SetCurrentSeason(Season season)
    {
        int index = Array.IndexOf(seasons, season);
        
        if (index == -1)
        {
            throw new Exception("Element not found in Seasons array");
        }
        
        currentSeasonIndex = index; 
        currentSeason = season;
    }
}
