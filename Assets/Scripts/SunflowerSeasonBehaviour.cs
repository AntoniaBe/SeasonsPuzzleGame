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
            case Season.SPRING:
                animationScript.sunflowerAnim.Play(lastSeason == Season.WINTER ? "Grow" : "Bloom_Backwards");
                break;
            case Season.SUMMER:
                animationScript.sunflowerAnim.Play(lastSeason == Season.SPRING ? "Bloom" : "Wilt_Backwards");
                break;

            case Season.AUTUMN:
                animationScript.sunflowerAnim.Play(lastSeason == Season.SUMMER ? "Wilt" : "Falling_Backwards");
                break;

            case Season.WINTER:
                animationScript.sunflowerAnim.Play(lastSeason == Season.AUTUMN ? "Falling" : "Grow_Backwards");
                break;
        }
    }

    private void Grow(){
        HandleAnimation(new bool[]{true, false, false, false, false});
    }

    private void Bloom(){
        HandleAnimation(new bool[]{false, true, false, false, false});
    }

    // private void Close(){
    //     HandleAnimation(new bool[]{false, false, false, true});
    // }

    private void Wither(){
        HandleAnimation(new bool[]{false, false, true, false, false});
    }

    private void Die(){
        HandleAnimation(new bool[]{false, false, false, true, false});
    }

    private void Idle(){
        HandleAnimation(new bool[]{false, false, false, false, true});
    }

    private void HandleAnimation(params bool[] states){
        animationScript.sunflowerIdleToGrow = states[0];
        animationScript.sunflowerGrowToBloom = states[1];
        animationScript.sunflowerBloomToWilt = states[2];
        animationScript.sunflowerWiltToFall = states[3];
        animationScript.sunflowerIdle = states[4];
    }

}
