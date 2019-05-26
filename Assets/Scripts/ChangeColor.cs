using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Blends between two materials

    public Material material1;
    public Material material2;
    float  speed = 1.0f;
    float start = 0;
    Renderer rend;
    float totalZ = 2.5f; // say it takes 4 seconds to complete the activity
    float currentZ = 0;   // the amount of time that has elapsed so far

    void Start()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = material1;
    }

    void Update()
    {
        currentZ += Time.deltaTime; // add time each frame
        float percentComplete = currentZ / totalZ; // value between 0 - 1
        percentComplete = Mathf.Clamp01(percentComplete);

        //float lerp = (Time.time - start) * speed;
        rend.material.Lerp(material1, material2, percentComplete);
    }
}
