using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersAnimation : MonoBehaviour
{

    public bool flowersIdle;
    public bool flowersGrow;
    public bool flowersBloom;
    public bool flowersGrowBack;

    public Animator [] redFlowers;
    public Animator[] purpleFlowers;
    public Animator[] idkFlowers;
    void Update()
    {
        //Grow
        if (flowersGrow)
        {
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
        //Bloom
        else if(flowersBloom) {

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
        //Wilt
        else if(flowersGrowBack)
        {
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
        //Idle
        else if (flowersIdle)
        {
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
}
