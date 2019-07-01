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
    private Season[] seasons;
    private int currentSeasonIndex;
    public Season lastActivatedSeason;

    public Season[] Seasons
    {
        get
        {
            return seasons;
        }
    }

    public Season CurrentSeason
    {
        get
        {
            return seasons[currentSeasonIndex];
        }
        set
        {
            int index = Array.IndexOf(seasons, value);

            if (index == -1)
            {
                throw new Exception("Element " + value +  " not found in Seasons array");
            }

            currentSeasonIndex = index;

            TriggerUpdateSeasonEvent();
        }
    }

    public Season NextSeason
    {
        get
        {
            int seasonIndex = currentSeasonIndex + 1;

            if (seasonIndex >= seasons.Length)
            {
                seasonIndex = 0;
            }

            return seasons[seasonIndex];
        }
    }

    public Season PreviousSeason
    {
        get
        {
            int seasonIndex = currentSeasonIndex - 1;

            if (seasonIndex < 0)
            {
                seasonIndex = seasons.Length - 1;
            }

            return seasons[seasonIndex];
        }
    }

    private void Awake()
    {
        UpdateSeasonEvent = new SeasonEvent();
        seasons = new Season[4] {Season.SPRING, Season.SUMMER, Season.AUTUMN, Season.WINTER};
        currentSeasonIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ChangeSeasonBackwards();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ChangeSeasonForwards();
        }
    }

    public Season ChangeSeasonForwards() 
    {
        lastActivatedSeason = CurrentSeason;
        currentSeasonIndex++;

        if (currentSeasonIndex >= seasons.Length)
        {
            currentSeasonIndex = 0;
        }
        TriggerUpdateSeasonEvent();
        return CurrentSeason;
    }

    public Season ChangeSeasonBackwards()
    {
        lastActivatedSeason = CurrentSeason;
        currentSeasonIndex--;

        if (currentSeasonIndex < 0)
        {
            currentSeasonIndex = seasons.Length - 1;
        }

        TriggerUpdateSeasonEvent();
        return CurrentSeason;
    }

    public void TriggerUpdateSeasonEvent()
    {
        UpdateSeasonEvent.Invoke(CurrentSeason);
    }
}
