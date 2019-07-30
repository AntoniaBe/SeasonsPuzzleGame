using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private Animator sunflowerAnim;

    [SerializeField]
    private Color[] blossomColors;

    [SerializeField]
    private LerpColor[] blossoms;

    [SerializeField]
    private Color[] coreColors;

    [SerializeField]
    private LerpColor core;

    public override void UpdateRepresentation(Season currentSeason){
        base.UpdateRepresentation(currentSeason);
        var lastSeason = SeasonsManager.Instance.lastActivatedSeason;

        switch(currentSeason)
        {
            case Season.SPRING:
                if(lastSeason == Season.WINTER){
                    sunflowerAnim.Play("Grow");
                    LerpColor(blossomColors[0]);
                    core.StartLerp(coreColors[0]);
                }else{
                    sunflowerAnim.Play("Bloom_Backwards");
                    LerpColor(blossomColors[0]);
                    core.StartLerp(coreColors[0]);
                }
                break;

            case Season.SUMMER:
                if(lastSeason == Season.SPRING){
                    sunflowerAnim.Play("Bloom");
                    LerpColor(blossomColors[1]);
                    core.StartLerp(coreColors[1]);
                }else{
                    sunflowerAnim.Play("Wilt_Backwards");
                    LerpColor(blossomColors[1]);
                    core.StartLerp(coreColors[1]);
                }
                break;

            case Season.AUTUMN:           
                if(lastSeason == Season.SUMMER){
                    sunflowerAnim.Play("Wilt");
                    LerpColor(blossomColors[2]);
                }else{
                    sunflowerAnim.Play("Falling_Backwards");
                    LerpColor(blossomColors[2]);
                }
                break;

            case Season.WINTER:
                if(lastSeason == Season.AUTUMN){
                    sunflowerAnim.Play("Falling");
                    LerpColor(blossomColors[2]);
                }else{
                    sunflowerAnim.Play("Grow_Backwards");
                    LerpColor(blossomColors[2]);
                }
                break;
        }
    }

    private void LerpColor(Color target){
        foreach(var blossom in blossoms){
            blossom.StartLerp(target);
        }
    }
}
