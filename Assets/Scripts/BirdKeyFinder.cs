using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdKeyFinder : MonoBehaviour
{
    [SerializeField]
    private Transform key;

    private BirdBehaviour behaviour;

    private void Start(){
        behaviour = GetComponent<BirdBehaviour>();
        behaviour.ChangeTarget(behaviour.GetSouthPosition().position);
    }

    private void Update(){
        if(Camera.main == null)
            return;

        StateManager stateManager = StateManager.Instance;
        // pick up key only when tutorial is done and player looks towards the key
        if(inFOV(key.position) && stateManager.TutorialDone()){
            behaviour.SetPickUpTarget(key);
        }
        // else{
        //     behaviour.GoIdle();
        // }
    }

    private bool inFOV(Vector3 pos){
        var screenPoint = Camera.main.WorldToViewportPoint(pos);
        // Debug.Log(screenPoint);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
