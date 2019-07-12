using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Material[] waterMaterials;

    [SerializeField]
    private Color normalColor;

    [SerializeField]
    private Color iceColor;

    [SerializeField]
    private float scaleWinter;

    [SerializeField]
    private float scaleNormal;

    [SerializeField]
    private float waterSpeed;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        if(currentSeason == Season.WINTER){
            foreach (Material waterMaterial in waterMaterials) {
                waterMaterial.SetColor("_WaterShallowColor", iceColor);
                waterMaterial.SetFloat("_WaterScale", scaleWinter);
                waterMaterial.SetFloat("_WaterSpeed", 0);
                waterMaterial.SetFloat("_WaterDepth", 0);
            }
        }
        else
        {
            Reset();
        }
    }

    private void Reset(){
        foreach (Material waterMaterial in waterMaterials)
        {
            waterMaterial.SetColor("_WaterShallowColor", normalColor);
            waterMaterial.SetFloat("_WaterScale", scaleNormal);
            waterMaterial.SetFloat("_WaterSpeed", waterSpeed);
            waterMaterial.SetFloat("_WaterDepth", 0.9f);
        }
    }

    private void OnApplicationQuit(){
        Reset();
    }
}
