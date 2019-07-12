using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    void Update()
    {
        if(Camera.main == null)
            return;

        transform.position = Camera.main.transform.position;
    }
}
