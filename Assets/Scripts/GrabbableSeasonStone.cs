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

        // Use the VRTK_SDKManager to get the right controllers
        //Debug.Log(Object.FindObjectOfType<VRTK_SDKManager>());
        //VRTK_SDKManager vrtkSdkManager = Object.FindObjectOfType<VRTK_SDKManager>();
        //if (vrtkSdkManager != null)
        //{
        //    Debug.Log(VRTK_SDKManager.GetAllSDKSetups()[0]);
        //}
        //else
        //{
        //    Debug.Log("No VRTK SDK Manager found");
        //}
    }

    private void SeasonStoneTouched(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Touched");

        Debug.Log(e.interactingObject);

        GameObject interactingObject = e.interactingObject;

        if (interactingObject == leftVrController || interactingObject == rightVrController)
        {
            interactedController = interactingObject;
            isTaken = true;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.localPosition += new Vector3(0, 0, 0.1f);
        }
        else
        {
            Debug.Log("No controller found.");
        }
    }

    private void Update()
    {
        if (isTaken)
        {
            // this.transform.position = interactedController.transform.position;
            // this.transform.position += new Vector3(0, 0.1f, 0);
            transform.parent = interactedController.transform;
        }
    }
}
