using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSeasonBehavior : SeasonObjectBehaviour
{
    private Light light;
    public Color springColor;
    public float springSunAngle;
    public float springIntensity;
    public Color summerColor;
    public float summerSunAngle;
    public float summerIntensity;
    public Color autumnColor;
    public float autumnSunAngle;
    public float autumnIntensity;
    public Color winterColor;
    public float winterSunAngle;
    public float winterIntensity;

    public override void Awake()
    {
        base.Awake();
        light = GetComponent<Light>();
    }

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        switch (currentSeason)
        {
            case Season.SPRING:
                light.color = springColor;
                transform.rotation = Quaternion.Euler(Vector3.right * springSunAngle);
                light.intensity = springIntensity;
                break;
            case Season.SUMMER:
                light.color = summerColor;
                transform.rotation = Quaternion.Euler(Vector3.right * summerSunAngle);
                light.intensity = summerIntensity;
                break;
            case Season.AUTUMN:
                light.color = autumnColor;
                transform.rotation = Quaternion.Euler(Vector3.right * autumnSunAngle);
                light.intensity = autumnIntensity;
                break;
            case Season.WINTER:
                light.color = winterColor;
                transform.rotation = Quaternion.Euler(Vector3.right * winterSunAngle);
                light.intensity = winterIntensity;
                break;
        }
    }
}
