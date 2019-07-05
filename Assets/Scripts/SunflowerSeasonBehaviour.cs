using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeasonBehaviour : SeasonObjectBehaviour
{
    [SerializeField]
    private SunflowerAnimationScript animationScript;

    [SerializeField]
    private Color[] blossomColors;

    [SerializeField]
    private LerpColor[] blossoms;

    public override void UpdateRepresentation(Season currentSeason){
        base.UpdateRepresentation(currentSeason);
        var lastSeason = SeasonsManager.Instance.lastActivatedSeason;
        Debug.Log(currentSeason + ", " + lastSeason);
        switch(currentSeason){
            case Season.SPRING:
                if(lastSeason == Season.WINTER){
                    animationScript.sunflowerAnim.Play("Grow");
                    LerpColor(blossomColors[0]);
                }else{
                    animationScript.sunflowerAnim.Play("Bloom_Backwards");
                    LerpColor(blossomColors[0]);
                }
                break;

            case Season.SUMMER:
            
                if(lastSeason == Season.SPRING){
                    animationScript.sunflowerAnim.Play("Bloom");
                    LerpColor(blossomColors[1]);
                }else{
                    animationScript.sunflowerAnim.Play("Wilt_Backwards");
                    LerpColor(blossomColors[1]);
                }
                break;

            case Season.AUTUMN:           
                if(lastSeason == Season.SUMMER){
                    animationScript.sunflowerAnim.Play("Wilt");
                    LerpColor(blossomColors[2]);
                }else{
                    animationScript.sunflowerAnim.Play("Falling_Backwards");
                    LerpColor(blossomColors[2]);
                }
                break;

            case Season.WINTER:
                if(lastSeason == Season.AUTUMN){
                    animationScript.sunflowerAnim.Play("Falling");
                    LerpColor(blossomColors[2]);
                }else{
                    animationScript.sunflowerAnim.Play("Grow_Backwards");
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

    private void SeasonSwitch(){
        
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
