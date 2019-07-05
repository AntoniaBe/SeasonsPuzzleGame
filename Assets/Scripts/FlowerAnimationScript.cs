using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnimationScript : MonoBehaviour
{

    public bool flowerIdle;
    public bool flowerGrow;
    public bool flowerBloom;
    public bool flowerGrowBack;

    public GameObject redFlower;
    public Animator redFlowerAnimator;

    public GameObject purpleFlower;
   // public Animator purplelowerAnimator;


    void Update()
    {
        if (flowerGrow)
        {
            redFlowerAnimator.SetBool("FlowersGrow", true);
            redFlowerAnimator.SetBool("FlowersIdle", false);
        }
        else if (flowerBloom)
        {
            redFlowerAnimator.SetBool("FlowersBloom", true);
        }
        else if (flowerGrowBack)
        {
            redFlowerAnimator.SetBool("FlowersGrowBack", true);
        }
        else if (flowerIdle)
        {
            redFlowerAnimator.SetBool("FlowersIdle", true);
            redFlowerAnimator.SetBool("FlowersGrow", false);
            redFlowerAnimator.SetBool("FlowersBloom", false);
            redFlowerAnimator.SetBool("FlowersGrowBack", false);
        }
    }
}
