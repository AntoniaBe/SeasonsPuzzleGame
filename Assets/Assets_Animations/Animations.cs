using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    public GameObject sunflower, carrot, carrotBody;
    float totalZ = 2.5f; // say it takes 4 seconds to complete the activity
    float currentZ = 0;   // the amount of time that has elapsed so far
    public GameObject[] sunflowerPartsGreenToColor, carrotShrubs;
    public bool sunflowerBool, carrotRottBool, carrotFreezeBool = false;
    private Animator sunflowerAnim, carrotAnim;
    public Material carrotNormalShrub, carrotRottenMaterial;

    // Start is called before the first frame update
    void Start()
    {
        sunflowerAnim = sunflower.GetComponent<Animator>();
        carrotAnim = carrot.GetComponent<Animator>();

        foreach (GameObject shrub in carrotShrubs)
        {
            shrub.GetComponent<Renderer>().material = carrotNormalShrub;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sunflowerBool) {

            currentZ += Time.deltaTime; // add time each frame
            float percentComplete = currentZ / totalZ; // value between 0 - 1
            percentComplete = Mathf.Clamp01(percentComplete);
            sunflowerAnim.Play("Sunflower_Bloom");
        foreach (GameObject sun in sunflowerPartsGreenToColor)
        {
            sun.GetComponent<Renderer>().material.SetFloat("_Blend", percentComplete);
        }
        } else if(carrotRottBool)
        {
            currentZ += Time.deltaTime;
            float percentComplete = currentZ / totalZ; 
            percentComplete = Mathf.Clamp01(percentComplete);
            carrotAnim.Play("Carrot_Rotten");
            carrotBody.GetComponent<Renderer>().material.SetFloat("_Blend", percentComplete);
            foreach (GameObject shrub in carrotShrubs)
            {
                shrub.GetComponent<Renderer>().material.Lerp(carrotNormalShrub, carrotRottenMaterial, percentComplete);
            }

        }




    }
}
