using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonObjectBehaviour : MonoBehaviour
{
    private SeasonsManager seasonsManager;

    void Start()
    {
        seasonsManager = SeasonsManager.Instance;
        seasonsManager.UpdateSeasonEvent.AddListener(UpdateRepresentation);
    }

    public virtual void UpdateRepresentation(Season currentSeason)
    {
        
    }
}
