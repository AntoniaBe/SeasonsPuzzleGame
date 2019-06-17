using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Texture defaultTexture = null;

    [SerializeField]
    private Texture skyBoxDefault = null;

    [SerializeField]
    private Material natureMaterial = null;

    [SerializeField]
    private Renderer skyBox = null;

    [SerializeField]
    private Texture[] skyBoxTextures = null;

    [SerializeField]
    private Texture[] environmentTextures = null;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        natureMaterial.mainTexture = environmentTextures[(int)currentSeason];
        skyBox.material.mainTexture = skyBoxTextures[(int)currentSeason];
    }

    private void OnApplicationQuit()
    {
        natureMaterial.mainTexture = defaultTexture;
    }
}
