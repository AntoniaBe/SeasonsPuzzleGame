using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private SunflowerAnimationScript animationScript;

    public override void UpdateRepresentation(Season currentSeason){
        base.UpdateRepresentation(currentSeason);
        var lastSeason = SeasonsManager.Instance.lastActivatedSeason;
        Debug.Log(currentSeason + ", " + lastSeason);
        switch(currentSeason){
            case Season.SUMMER:
                Bloom();
                break;

            case Season.AUTUMN:
                if(lastSeason == Season.SUMMER){
                    Wither();
                }else{
                    ReBloom();
                }
                break;

            case Season.WINTER:
                if(lastSeason == Season.AUTUMN){
                    ReBloom();
                }else{
                    Shrink();
                }
                break;

            case Season.SPRING:
                if(lastSeason == Season.WINTER){
                    Grow();
                }
                else{
                    Close();
                }
                break;
        }
    }

    private void Grow(){
        HandleAnimation(new bool[]{true, false, false, false, false, false, false});
    }

    private void Shrink(){
        HandleAnimation(new bool[]{false, true, false, false, false, false, false});
    }

    private void Bloom(){
        HandleAnimation(new bool[]{false, false, true, false, false, false, false});
    }

    private void Close(){
        HandleAnimation(new bool[]{false, false, false, true, false, false, false});
    }

    private void Wither(){
        HandleAnimation(new bool[]{false, false, false, false, true, false, false});
    }

    private void ReBloom(){
        HandleAnimation(new bool[]{false, false, false, false, false, true, false});
    }

    private void Idle(){
        HandleAnimation(new bool[]{false, false, false, false, false, false, true});
    }

    private void HandleAnimation(params bool[] states){
        animationScript.sunflowerIdleToGrow = states[0];
        animationScript.sunflowerGrowToIdle = states[1];
        animationScript.sunflowerGrowToBloom = states[2];
        animationScript.sunflowerBloomToGrow = states[3];
        animationScript.sunflowerBloomToWilt = states[4];
        animationScript.sunflowerWiltToBloom = states[5];
        animationScript.sunflowerIdle = states[6];
    }

}
