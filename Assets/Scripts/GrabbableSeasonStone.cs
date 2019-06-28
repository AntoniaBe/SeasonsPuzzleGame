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

            seasonController.AttachSeasonStone(this);
            IsTaken = true;
        }
        else
        {
            Debug.Log("No controller found.");
        }
    }
}
