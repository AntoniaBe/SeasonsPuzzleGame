using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonObjectBehaviour : MonoBehaviour
{
    private SeasonsManager seasonsManager;

    private void Start()
    {
        seasonsManager = SeasonsManager.Instance;
        seasonsManager.UpdateSeasonEvent.AddListener(OnUpdateRepresentation);
    }

    private void OnUpdateRepresentation(Season currentSeason)
    {
        UpdateRepresentation(currentSeason);
    }

    public virtual void UpdateRepresentation(Season currentSeason)
    {
    }
    
}
