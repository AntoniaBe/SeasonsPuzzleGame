using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonObjectBehaviour : MonoBehaviour
{
    public virtual void Awake(){
        SeasonsManager.Instance.UpdateSeasonEvent.AddListener(OnUpdateRepresentation);
    }

    private void OnUpdateRepresentation(Season currentSeason)
    {
        UpdateRepresentation(currentSeason);
    }

    public virtual void UpdateRepresentation(Season currentSeason)
    {
    }
    
}
