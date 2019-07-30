using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BoxBehavior : MonoBehaviour
{
    private bool isOpened;
    public AudioSource closedChestAudioSource;

    private void Start(){
        isOpened = false;
        GameObject lid = transform.GetChild(0).gameObject;
        // add event whenever chest is touched and play the closed chest sound
        if (lid.GetComponent<VRTK_InteractableObject>())
        {
            lid.GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += PlayClosedChestSound;
        }
        else
        {
            Debug.LogError("lid of chest has no VRTK_InteractableObject component");
        }
    }

    void OnCollisionEnter (Collision col)
    {
        // open the chest with the key
        if(col.gameObject.tag == "Key" && !isOpened)
        {
            gameObject.transform.Find("SM_Prop_Chest_Wood_Lid").GetComponent<Animator>().Play("Open");
            StateManager stateManager = StateManager.Instance;
            stateManager.ChestOpen();
            isOpened = true;
        }
    }

    private void PlayClosedChestSound(object sender, InteractableObjectEventArgs e)
    {
        if (!isOpened)
        {
            Debug.Log("play sound");
            closedChestAudioSource.Play();
        }
    }
}
