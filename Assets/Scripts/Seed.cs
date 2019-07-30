using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Seed : MonoBehaviour
{
    private bool isTaken;
    private BirdBehaviour[] birds;

    void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += SeedGrabbed;
        birds = FindObjectsOfType<BirdBehaviour>();
    }

    private void SeedGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isTaken = true;
        GetComponent<SeasonSunflowerSeedBehavior>().enabled = false;
        
        foreach (var bird in birds)
        {
            // let the birds fly towards the seed
            bird.SetPickUpTarget(transform);
        }
    }
}
