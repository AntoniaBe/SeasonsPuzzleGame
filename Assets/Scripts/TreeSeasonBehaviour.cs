using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeasonBehaviour : SeasonObjectBehaviour
{
    public Material[] seasonMaterials;

    public Vector4 bigWavesValues;
    public Vector4 bigSpeedValues;
    public Vector4 bigAmountValues;
    public Vector4 smallWavesValues;
    public Vector4 smallSpeedValues;
    public Vector4 smallAmountValues;



    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        SetMaterial(seasonMaterials[(int)currentSeason], currentSeason);
    }

    private void SetMaterial(Material material, Season current)
    {
        var newMaterials = GetComponentInChildren<Renderer>().materials;
        newMaterials[newMaterials.Length - 1] = material;
        GetComponentInChildren<Renderer>().materials = newMaterials;
        adjustWindValues(newMaterials, current);
    }

    private void adjustWindValues(Material[] newMaterials, Season season)
    {
        foreach (Material material in newMaterials)
        {
            material.SetFloat("Big_Wave", bigWavesValues[(int)season]);
            material.SetFloat("Big_WindSpeed", bigSpeedValues[(int)season]);
            material.SetFloat("Big_WindAmount", bigAmountValues[(int)season]);

            material.SetFloat("Small_Wave", smallWavesValues[(int)season]);
            material.SetFloat("Small_Windspeed", smallSpeedValues[(int)season]);
            material.SetFloat("Small_WindAmount", smallAmountValues[(int)season]);
        }
    }
}
