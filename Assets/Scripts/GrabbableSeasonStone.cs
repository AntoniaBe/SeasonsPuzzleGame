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
    private GameObject interactedController;
    private bool isTaken;

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;

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
            interactedController = interactingObject;

            isTaken = true;
            transform.parent = interactedController.transform;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.localPosition += new Vector3(0, 0.1f, 0);
        }
        else
        {
            Debug.Log("No controller found.");
        }
    }
}
