using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class NatureSeasonBehaviour : SeasonObjectBehaviour
{
    //TODO später soll jedes object in seinen individuellen status wechseln.
    [SerializeField]
    private GameObject[] toggleObjects;

    [SerializeField]
    private GameObject snow;

    [SerializeField]
    private GameObject rain;

    [SerializeField]
    private Texture defaultTexture = null;

    [SerializeField]
    private Material[] natureMaterials = null;

    [SerializeField]
    private Material[] skyBoxMaterials = null;

    [SerializeField]
    private Texture[] skyBoxTextures = null;

    public  BackgroundGrayManager backgroundTextureManager;

    [SerializeField]
    private Texture[] environmentTextures = null;

    private void Start()
    {
       backgroundTextureManager = FindObjectOfType<BackgroundGrayManager>();
    }

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        giveAllNatureMaterialsNewSeasonTexture( currentSeason );
        giveAllSkyMaterialsNewSeasonTexture( currentSeason );

        var isWinter = currentSeason == Season.WINTER;
        snow.SetActive(isWinter);
        foreach(var obj in toggleObjects)
        {
            obj.SetActive(!isWinter);
        }

        rain.SetActive(currentSeason == Season.AUTUMN);

    }

    private void OnApplicationQuit()
    {
        foreach ( Material material in natureMaterials )
        {
            material.mainTexture = defaultTexture;
        }
    }

    private void giveAllNatureMaterialsNewSeasonTexture(Season currentSeason) {
        foreach(Material material in natureMaterials )
        {
           material.mainTexture = environmentTextures[ (int) currentSeason ];
        }

    }

    private void giveAllSkyMaterialsNewSeasonTexture( Season currentSeason )
    {

        foreach ( Material material in skyBoxMaterials )
        {
            material.mainTexture = skyBoxTextures[ (int) currentSeason ];
        }


    }
}
