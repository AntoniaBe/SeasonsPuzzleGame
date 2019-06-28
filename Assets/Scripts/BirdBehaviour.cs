using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    private float steeringSpeed;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float minDist;

    [SerializeField]
    private GameObject sdkSetup;

    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("Flying", true);
    }

    private void Update(){
        
        var target = sdkSetup.GetComponentInChildren<Camera>().transform;
        if(target == null)
            return;

        if(Vector3.Distance(transform.position, target.position) > minDist){
            var targetDir = target.position - transform.position;
            var newDir = Vector3.RotateTowards(transform.forward, targetDir, steeringSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            var pos = transform.position;
            pos += transform.forward * speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
