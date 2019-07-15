using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SkyboxBehaviour : SeasonObjectBehaviour
{
    
public Material springSky;
public Material summerSky;
public Material autumnSky;
public Material winterSky;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        switch (currentSeason)
        {
            case(Season.SPRING): 
                RenderSettings.skybox = springSky;
                break;
            case(Season.SUMMER): 
                RenderSettings.skybox = summerSky;
                break;
            case(Season.AUTUMN): 
                RenderSettings.skybox = autumnSky;
                break;
            case(Season.WINTER): 
                RenderSettings.skybox = winterSky;
                break;
        }    
    }
}
