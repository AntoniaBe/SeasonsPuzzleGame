using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerAnimationScript : MonoBehaviour
{
    public GameObject sunflower;
    float totalZ = 4f; // say it takes 4 seconds to complete the animation
    float currentZ = 0;   // the amount of time that has elapsed so far
    public GameObject[] sunflowerPartsGreenToColor;
    public bool sunflowerIdleToGrow = false;
    public bool sunflowerGrowToIdle = false;
    public bool sunflowerGrowToBloom = false;
    public bool sunflowerBloomToGrow = false;
    public bool sunflowerBloomToWilt = false;
    public bool sunflowerWiltToBloom = false;
    public bool sunflowerIdle = false;

    public Animator sunflowerAnim;

    void Start()
    {
        sunflowerAnim = sunflower.GetComponent<Animator>();
    } 

    void Update()
    {

        //Sonnenblume wächst
        if (sunflowerIdleToGrow)
        {
            sunflowerAnim.SetBool("Grow", true);
            sunflowerAnim.SetBool("Idle", false);
            sunflowerAnim.SetBool("Wilt", false);
        }

        //Sonnenblume wächst zurück
        if (sunflowerGrowToIdle)
        {
            sunflowerAnim.SetBool("Grow", false);

        }


        //Sonnenblume öffnet sich
        if (sunflowerGrowToBloom)
        {
           //Debug.Log("sunflowerGrowToBloom " + currentZ);
           

            if (currentZ < 0)
            {
                currentZ = 0;

            } else
            {
                currentZ += Time.deltaTime;
                float percentComplete = currentZ / totalZ; // value between 0 - 1
                percentComplete = Mathf.Clamp01(percentComplete);
                //Debug.Log("sunflowerGrowToBloom, percentComplete " + percentComplete);
                foreach (GameObject sun in sunflowerPartsGreenToColor)
                {
                    sun.GetComponent<Renderer>().material.SetFloat("_Blend", percentComplete);
                }
                sunflowerAnim.SetBool("Bloom", true);
            }
           
        }

        //Sonnenblume schließt sich wieder
        if (sunflowerBloomToGrow)
        {
            if(currentZ > 4)
            {
                currentZ = 4;
            } else
            {
                currentZ -= Time.deltaTime; // add time each frame
                float percentComplete = currentZ / totalZ; // value between 1 - 0
                percentComplete = Mathf.Clamp01(percentComplete);
               // Debug.Log("sunflowerBloomToGrow, percentComplete " + percentComplete);
                foreach (GameObject sun in sunflowerPartsGreenToColor)
                {
                    sun.GetComponent<Renderer>().material.SetFloat("_Blend", percentComplete);
                }
                sunflowerAnim.SetBool("Bloom", false);
            }
           
        }

        //Sonnenblume verwelkt
        if (sunflowerBloomToWilt)
        {
            sunflowerAnim.SetBool("Wilt", true);
        }

        //Sonnenblume blüht wieder
        if (sunflowerWiltToBloom)
        {
            sunflowerAnim.SetBool("Wilt", false);
        }

        //Nichts, Sonnenblume wurde hier eingefplanzt? 
        if (sunflowerIdle)
        {
            sunflowerAnim.SetBool("Idle", true);
            sunflowerAnim.SetBool("Grow", false);
            sunflowerAnim.SetBool("Bloom", false);


        }
    }

}
