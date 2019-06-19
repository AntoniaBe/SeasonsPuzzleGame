using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public bool hasSpringStone;
    public bool hasSummerStone;
    public bool hasAutumnStone;
    public bool hasWinterStone;

    private void Awake()
    {
        hasSpringStone = hasSummerStone = hasAutumnStone = hasWinterStone = false;
    }

    public bool CanChangeToSeason(Season season)
    {
        bool canChangeToSeason;

        switch (season)
        {
            case Season.AUTUMN:
                canChangeToSeason = hasAutumnStone;
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

    public void SetSeasonPower(Season season, bool isActivated)
    {
        switch (season)
        {
            case Season.AUTUMN:
                hasAutumnStone = isActivated;
                break;
            case Season.SPRING:
                hasSpringStone = isActivated;
                break;
            case Season.SUMMER:
                hasSummerStone = isActivated;
                break;
            case Season.WINTER:
                hasWinterStone = isActivated;
                break;
            default:
                break;
        }
    }
}
