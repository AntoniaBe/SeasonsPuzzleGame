using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GrabbableSeasonStone : MonoBehaviour
{
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
        Debug.Log(sender);
        Debug.Log("touched");
    }
}
