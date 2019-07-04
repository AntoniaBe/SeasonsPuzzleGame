﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSeasonBehaviour : SeasonObjectBehaviour
{
    //TODO später soll jedes object in seinen individuellen status wechseln.
    [SerializeField]
    private GameObject[] toggleObjects;

    [SerializeField]
    private GameObject snow;

    [SerializeField]
    private Texture defaultTexture = null;

    [SerializeField]
    private Material[] natureMaterials = null;

    [SerializeField]
    private Renderer skyBox = null;

    [SerializeField]
    private Texture[] skyBoxTextures = null;

    [SerializeField]
    private Texture[] environmentTextures = null;

    private bool isWinter;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        giveAllNatureMaterialsNewSeasonTexture( currentSeason );
        skyBox.material.mainTexture = skyBoxTextures[(int)currentSeason];
        isWinter = currentSeason == Season.WINTER;
        snow.SetActive(isWinter);
        foreach(var obj in toggleObjects)
        {
            obj.SetActive(!isWinter);
        }
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
}
