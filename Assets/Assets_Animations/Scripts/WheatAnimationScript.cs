using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatAnimationScript : MonoBehaviour
{
    public GameObject wheatContainer;
    public bool wheatGrowLittle;
    public bool wheatGrowFull;
    public bool wheatGrowBackLittle;
    public bool wheatGrowBackFull;
    public bool wheatIdle;
    public Animator wheatAnimator;

    void Update()
    {
        if (wheatGrowLittle)
        {
            wheatAnimator.Play("WheatGrowLittle");
        }

        else if(wheatGrowFull)
        {
            wheatAnimator.Play("WheatGrowFull");
        }
        else if (wheatGrowBackLittle)
        {
            wheatAnimator.Play("WheatGrowBackLittle");

        }
        else if (wheatGrowBackFull)
        {
            wheatAnimator.Play("WheatGrowFullBack");

        }
        else if (wheatIdle)
        {
            wheatAnimator.Play("WheatIdle");
        }
    }
}
