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
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += SeedTouched;
        birds = FindObjectsOfType<BirdBehaviour>();
    }

    private void SeedTouched(object sender, InteractableObjectEventArgs e)
    {
        isTaken = true;
        
        foreach (var bird in birds)
        {
            bird.PickUp(transform);
        }
    }
}
