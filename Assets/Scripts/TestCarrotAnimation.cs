using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCarrotAnimation : MonoBehaviour
{
    public GameObject karotte_container, karotte_container2, karotte, strauch1, strauch2, strauch3, strauch4, strauch5;
    bool freezeToggle= true;
    void Start()
    {
        karotte_container.GetComponent<Animator>().enabled = false;

        karotte.GetComponent<ChangeTexture>().enabled = false;
        strauch1.GetComponent<ChangeColor>().enabled = false;
        strauch2.GetComponent<ChangeColor>().enabled = false;
        strauch3.GetComponent<ChangeColor>().enabled = false;
        strauch4.GetComponent<ChangeColor>().enabled = false;
        strauch5.GetComponent<ChangeColor>().enabled = false;
    }

    public void MakeCarrotRotten()
    {
        karotte_container.GetComponent<Animator>().enabled = true;
        karotte.GetComponent<ChangeTexture>().enabled = true;
        strauch1.GetComponent<ChangeColor>().enabled = true;
        strauch2.GetComponent<ChangeColor>().enabled = true;
        strauch3.GetComponent<ChangeColor>().enabled = true;
        strauch4.GetComponent<ChangeColor>().enabled = true;
        strauch5.GetComponent<ChangeColor>().enabled = true;
    }

    public void FreezeCarrot()
    {


        freezeToggle = !freezeToggle;

        if (freezeToggle)
        {
            karotte_container2.GetComponent<Animator>().Play("Unfreeze");

        }
      
        else
        {
            karotte_container2.GetComponent<Animator>().Play("Freeze");
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
