using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SeasonSunflowerSeedBehavior : SeasonObjectBehaviour
{
    public Season sunflowerSeason;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        gameObject.SetActive(currentSeason.Equals(sunflowerSeason));
    }
}
