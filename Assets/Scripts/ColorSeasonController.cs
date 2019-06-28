using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSeasonController : SeasonObjectBehaviour
{
    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private Color[] colors;

    [SerializeField]
    private Material material;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        material.color = colors[(int)currentSeason];
    }

    private void OnApplicationQuit()
    {
        material.color = defaultColor;
    }
}
