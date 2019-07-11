using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{

    public bool chestIdle = true;
    public bool chestOpen = false;
    public bool chestClose = false;
    public Animator chestAnimator;



    void Update()
    {
        if (chestOpen)
        {
            chestAnimator.Play("Open");
        } 
        else if (chestClose)
        {
            chestAnimator.Play("Close");
        }
        else if (chestIdle)
        {
            chestAnimator.Play("Idle");
        }
    }
}
