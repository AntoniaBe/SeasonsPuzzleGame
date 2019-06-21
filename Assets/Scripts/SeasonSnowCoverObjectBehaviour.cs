using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonSnowCoverObjectBehaviour : SeasonObjectBehaviour
{
    private LerpProperty lerpScaleBehaviour;
    private bool direction = true;
    private Season lastSeason;

    public override void Start()
    {
        base.Start();
        lerpScaleBehaviour = GetComponentInChildren<LerpProperty>();
    }

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        Debug.Log(currentSeason);
        if (currentSeason == Season.WINTER)
        {
            Lerp();
        }
        else if(currentSeason != Season.WINTER && lastSeason == Season.WINTER)
        {
            Lerp();
        }
        lastSeason = currentSeason;
    }

    private void Lerp()
    {
        direction = !direction;
        lerpScaleBehaviour.Lerp(direction);
    }
}
