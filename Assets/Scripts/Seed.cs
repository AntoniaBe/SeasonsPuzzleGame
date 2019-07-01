using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Seed : MonoBehaviour
{
    private bool isTaken;
    private BirdBehaviour[] birds;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += SeedTouched;
        birds = FindObjectsOfType<BirdBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
