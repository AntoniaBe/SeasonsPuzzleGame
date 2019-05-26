using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    // Blends between two materials

    public Material material;
    Renderer rend;
    float totalZ = 2.5f; // say it takes 4 seconds to complete the activity
    float currentZ = 0;   // the amount of time that has elapsed so far

    void Start()
    {
        rend = GetComponent<Renderer>();
        // At start, use the first material
        rend.material = material;
    }

    void Update()
    {
        currentZ += Time.deltaTime; // add time each frame
        float percentComplete = currentZ / totalZ; // value between 0 - 1
        percentComplete = Mathf.Clamp01(percentComplete);
        rend.material.SetFloat("_Blend", percentComplete);
    }





}
