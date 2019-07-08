using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatAnimationScript : SeasonObjectBehaviour
{
    public GameObject wheatContainer;

    public Animator wheatAnimator;


public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        var lastSeason = SeasonsManager.Instance.lastActivatedSeason;
        Debug.Log(currentSeason + ", " + lastSeason);
        switch(currentSeason){
            case Season.SPRING:
            if(lastSeason == Season.WINTER){
                GrowLittle();
                }else{
     
                }
                break;


            case Season.SUMMER:
             if(lastSeason == Season.SPRING){
                    GrowFull();
                }else{
                     return;
                }
                break;
            
            case Season.AUTUMN:
                if(lastSeason == Season.SUMMER){
                    GrowBackLittle();
                }else{
                return;
                }
                break;


            case Season.WINTER:
                if(lastSeason == Season.AUTUMN){
                   GrowBackFull();
                }else{
                    return;
                }
                break;

        }
    }


    private void GrowLittle() {
         wheatAnimator.Play("WheatGrowLittle");
    }

    private void GrowFull() {
         wheatAnimator.Play("WheatGrowFull");
    }

    private void GrowBackLittle() {
         wheatAnimator.Play("WheatGrowBackLittle");
    }

        private void GrowBackFull() {
          wheatAnimator.Play("WheatGrowFullBack");
    }

    private void Idle() {
         wheatAnimator.Play("WheatIdle");
    }

}
