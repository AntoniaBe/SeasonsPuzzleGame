﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GrabbableSeasonStone : MonoBehaviour
{
    [SerializeField]
    private GameObject leftVrController;
    [SerializeField]
    private GameObject rightVrController;

    public Season season;
    private GameObject interactedController;

    public bool IsGrabbable {get; set;} 

    public bool IsTaken {get; set;}

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        IsTaken = false;

        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.Log("Season Stone has no InteractableObject script property");
        } else
        {
            GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += SeasonStoneTouched;
        }
    }

    private void SeasonStoneTouched(object sender, InteractableObjectEventArgs e)
    {
        GameObject interactingObject = e.interactingObject;

        if (IsGrabbable && (interactingObject == leftVrController || interactingObject == rightVrController))
        {
            SeasonController seasonController = interactingObject.GetComponent<SeasonController>();

            if (seasonController == null)
                throw new Exception("The interacting controller has no SeasonController script component");

    	    // remove rigidbody so that the season stone stays attached to the controller
            if(rb != null){
                rb.detectCollisions = false;
                Destroy(rb);
            }

            // deactivate collider of season stone to prevent unwanted collisions with gameobjects
            GetComponent<Collider>().enabled = false;
            
            seasonController.AttachSeasonStone(this);
            IsTaken = true;
            
            StateManager.Instance.OnStoneTaken.Invoke(this);
        }
        else
        {
            Debug.Log("No controller found.");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // makes a stone fall down when touched with a stick tagged object
        if(other.gameObject.CompareTag("Stick") && GetComponent<Rigidbody>() == null && season == Season.SPRING){
            rb = gameObject.AddComponent<Rigidbody>();
            IsGrabbable = true;
        }
    }
}
