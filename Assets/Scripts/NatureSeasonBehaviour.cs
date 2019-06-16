using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Material natureMaterial;

    [SerializeField]
    private Texture[] textures = null;

    public override void UpdateRepresentation(Season currentSeason)
    {
        natureMaterial.mainTexture = textures[(int)currentSeason];
    }
}
