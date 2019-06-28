using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimationScript : MonoBehaviour
{

    public GameObject bird;
    public Animator birdAnimator;
    public bool birdFlying = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (birdFlying)
        {
            birdAnimator.SetBool("Flying", true);
        }
        else if(!birdFlying)
        {
            birdAnimator.SetBool("Flying", false);
        }
        
    }
}
