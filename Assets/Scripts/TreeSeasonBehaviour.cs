using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Texture[] textures = null;

    public override void UpdateRepresentation(Season currentSeason)
    {
        Debug.Log(currentSeason);
        foreach (var rend in GetComponentsInChildren<Renderer>())
        {
            Debug.Log(rend.name);
            rend.material.SetTexture("_MainTexture", textures[(int)currentSeason]);
        }
    }
}
