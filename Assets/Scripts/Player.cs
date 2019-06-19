using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public bool hasSpringStone;
    public bool hasSummerStone;
    public bool hasFallStone;
    public bool hasWinterStone;

    private void Awake()
    {
        hasSpringStone = hasSummerStone = hasFallStone = hasWinterStone = false;
    }

    public bool CanChangeToSeason(Season season)
    {
        bool canChangeToSeason;

        switch (season)
        {
            case Season.FALL:
                canChangeToSeason = hasFallStone;
                break;
            case Season.SPRING:
                canChangeToSeason = hasSpringStone;
                break;
            case Season.SUMMER:
                canChangeToSeason = hasSummerStone;
                break;
            case Season.WINTER:
                canChangeToSeason = hasWinterStone;
                break;
            default:
                canChangeToSeason = false;
                break;
        }

        return canChangeToSeason;
    }
}
