using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLevelKey : MonoBehaviour
{
    [SerializeField]
    private Transform key;

    private BirdBehaviour behaviour;

    private void Start(){
        behaviour = GetComponent<BirdBehaviour>();
    }

    private void Update(){
        if(Camera.main == null)
            return;

        if(inFOV(key.position)){
            behaviour.SetPickUpTarget(key);
        }
        else{
            behaviour.GoIdle();
        }
    }

    private bool inFOV(Vector3 pos){
        var screenPoint = Camera.main.WorldToViewportPoint(pos);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
