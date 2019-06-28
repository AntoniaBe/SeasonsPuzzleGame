using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Material[] seasonMaterials;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        SetMaterial(seasonMaterials[(int)currentSeason]);
    }

    private void SetMaterial(Material material)
    {
        var newMaterials = GetComponentInChildren<Renderer>().materials;
        newMaterials[newMaterials.Length - 1] = material;
        GetComponentInChildren<Renderer>().materials = newMaterials;
    }
}
