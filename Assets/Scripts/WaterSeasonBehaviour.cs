using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Material waterMaterial;

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
            waterMaterial.SetColor("_WaterShallowColor", iceColor);
            waterMaterial.SetFloat("_WaterScale", scaleWinter);
            waterMaterial.SetFloat("_WaterSpeed", 0);
        }
        else
        {
            Reset();
        }
    }

    private void Reset(){
            waterMaterial.SetColor("_WaterShallowColor", normalColor);
            waterMaterial.SetFloat("_WaterScale", scaleNormal);
            waterMaterial.SetFloat("_WaterSpeed", waterSpeed);
    }

    private void OnApplicationQuit(){
        Reset();
    }
}
