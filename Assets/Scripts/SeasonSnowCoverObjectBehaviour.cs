using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonSnowCoverObjectBehaviour : SeasonObjectBehaviour
{
    private LerpScaleBehaviour lerpScaleBehaviour;

    public override void Start()
    {
        base.Start();
        lerpScaleBehaviour = GetComponentInChildren<LerpScaleBehaviour>();
    }

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        Debug.Log(currentSeason);
        if(currentSeason == Season.WINTER)
        {
            lerpScaleBehaviour.Lerp();
        }
        else
        {
            if(SeasonsManager.Instance.PreviousSeason == Season.WINTER || SeasonsManager.Instance.NextSeason == Season.WINTER)
            {
                lerpScaleBehaviour.Lerp();
            }
        }
    }
}
