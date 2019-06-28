using System;
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

    private bool isGrabbable; 

    // Start is called before the first frame update
    void Start()
    {
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

        if (interactingObject == leftVrController || interactingObject == rightVrController)
        {
            SeasonController seasonController = interactingObject.GetComponent<SeasonController>();

            if (seasonController == null)
                throw new Exception("The interacting controller has no SeasonController script component");

            seasonController.AttachSeasonStone(this);
        }
        else
        {
            Debug.Log("No controller found.");
        }
    }
}
