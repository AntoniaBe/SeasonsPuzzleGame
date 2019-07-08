using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersAnimation : SeasonObjectBehaviour
{
    public Animator [] redFlowers;
    public Animator[] purpleFlowers;
    public Animator[] idkFlowers;

    public override void UpdateRepresentation(Season currentSeason)
    {
        base.UpdateRepresentation(currentSeason);
        var lastSeason = SeasonsManager.Instance.lastActivatedSeason;
        Debug.Log(currentSeason + ", " + lastSeason);
        switch(currentSeason){
            case Season.SPRING:
            if(lastSeason == Season.WINTER){
                Grow();
                }else{
                GrowBack(); 
                }
                break;


            case Season.SUMMER:
             if(lastSeason == Season.SPRING){
                    Bloom();
                }else{
                     return;
                }
                break;
            
            case Season.AUTUMN:
                if(lastSeason == Season.SUMMER){
                    Wilt();
                }else{
                return;
                }
                break;


            case Season.WINTER:
                if(lastSeason == Season.AUTUMN){
                   Idle();
                }else{
                    return;
                }
                break;

        }
    }

    private void Grow(){
        foreach(Animator redFlower in redFlowers)
        {
            redFlower.Play("FlowersGrow");
        }

        foreach (Animator purpleFlower in purpleFlowers)
        {
            purpleFlower.Play("PurpleFlowerGrowLittle");
        }

        foreach (Animator idkFlower in idkFlowers)
        {
            idkFlower.Play("Grow");
        }

    }

    private void GrowBack() {
        foreach(Animator redFlower in redFlowers)
        {
            redFlower.Play("FlowersGrow_-1");
        }

        foreach (Animator purpleFlower in purpleFlowers)
        {
            purpleFlower.Play("PurpleFlowerGrowLittle_-1");
        }

        foreach (Animator idkFlower in idkFlowers)
        {
            idkFlower.Play("Grow_-1");
        }
    }

    private void Bloom(){
        foreach (Animator redFlower in redFlowers)
        {
            redFlower.Play("FlowersBloom");
        }

        foreach (Animator purpleFlower in purpleFlowers)
        {
            purpleFlower.Play("PurpleFlowerGrowFull");
        }

        foreach (Animator idkFlower in idkFlowers)
        {
            idkFlower.Play("Bloom");
        }

    }

    private void Wilt(){
        foreach (Animator redFlower in redFlowers)
        {
            redFlower.Play("GrowBack");
        }

        foreach (Animator purpleFlower in purpleFlowers)
        {
            purpleFlower.Play("PurpleFlowerGrowBackFull");
        }

        foreach (Animator idkFlower in idkFlowers)
        {
            idkFlower.Play("GrowBack");
        }
    }

    private void Idle(){
        foreach (Animator redFlower in redFlowers)
        {
            redFlower.Play("FlowersIdle");
        }

        foreach (Animator purpleFlower in purpleFlowers)
        {
            purpleFlower.Play("PurpleFlowerIdle");
        }

        foreach (Animator idkFlower in idkFlowers)
        {
            idkFlower.Play("Idle");
        }
    }
}
