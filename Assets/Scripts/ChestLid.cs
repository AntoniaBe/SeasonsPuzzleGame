using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ChestLid : MonoBehaviour
{
    private AudioSource closedChestAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        closedChestAudioSource = GetComponent<AudioSource>();
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += ChestGrabbed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChestGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("play sound");
        if (true)
        {
            closedChestAudioSource.Play();
        }
    }
}
