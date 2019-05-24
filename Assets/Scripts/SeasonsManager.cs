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
    public UnityEvent<Season> UpdateSeason;
    private Season currentSeason;

    private void Awake()
    {
        UpdateSeason = new SeasonEvent();
    }

    private void Start()
    {
        UpdateSeason.Invoke(Season.WINTER);
    }
}
