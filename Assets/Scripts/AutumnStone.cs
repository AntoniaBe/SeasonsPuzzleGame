using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnStone : SeasonObjectBehaviour
{
    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        if ((currentSeason == Season.AUTUMN || currentSeason == Season.WINTER) && GetComponent<GrabbableSeasonStone>().IsTaken == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
