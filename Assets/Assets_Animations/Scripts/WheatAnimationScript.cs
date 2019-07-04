using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatAnimationScript : MonoBehaviour
{
    public GameObject wheatContainer;
    public bool wheatGrowLittle;
    public bool wheatGrowFull;
    public bool wheatGrowBackLittle;
    public bool wheatIdle;
    public Animator wheatAnimator;

    void Update()
    {
        if (wheatGrowLittle)
        {
            wheatAnimator.SetBool("WheatGrowLittle", true);
            wheatAnimator.SetBool("WheatIdle", false);
        }

        else if(wheatGrowFull)
        {
            wheatAnimator.SetBool("WheatGrowFull", true);
        }
        else if (wheatGrowBackLittle)
        {
            wheatAnimator.SetBool("WheatGrowBackLittle", true);

        }
        else if (wheatIdle)
        {
            wheatAnimator.SetBool("WheatIdle", true);
            wheatAnimator.SetBool("WheatGrowLittle", false);
            wheatAnimator.SetBool("WheatGrowFull", false);
            wheatAnimator.SetBool("WheatGrowBackLittle", false);

        }
    }
}
