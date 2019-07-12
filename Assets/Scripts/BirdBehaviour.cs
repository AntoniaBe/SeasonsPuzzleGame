using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    private float steeringSpeed;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float minDist;

    [SerializeField]
    private float breakForce;

    [SerializeField]
    private GameObject sdkSetup;

    [SerializeField]
    private Transform claws;

    private Animator animator;
    private Vector3 target;
    private Transform targetTransform;

    [SerializeField]
    private Season[] flyingSeasons;
    [SerializeField]
    private float peckingTime;
    [SerializeField]
    private Transform south;
    [SerializeField]
    private Transform gatheringPosition;
    // private float startPeckingTime;
 

    private bool isPecking;

    void Awake()
    {
        SeasonsManager.Instance.UpdateSeasonEvent.AddListener(OnSeasonUpdate);
    }

    private void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("Flying", true);
        // start in winter -> fly to south
        ChangeTarget(south.position);
        isPecking = false;
    }

    private void Update()
    {
        // pecking seeds
        if (isPecking)
            return;

        // abort chasing targetTransform, if it is null or south
        if(targetTransform != null && target != south.position)
            target = targetTransform.position;

        // continue flying towards target
        var dist = Vector3.Distance(transform.position, target);
        if(dist > minDist || target == south.position)
        {

            Debug.DrawRay(transform.position, transform.forward, Color.green);
            RaycastHit hit;
            var targetDir = target - transform.position;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    targetDir = Vector3.up;
                }
            }

            var targetRotation = Vector3.RotateTowards(transform.forward, targetDir, steeringSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(targetRotation);
                
            // break at min distance
            dist = dist > 1 ? 1 : dist;
            var breakFactor = targetTransform == null ? 1 : dist * breakForce;

            // fly forwards
            var pos = transform.position;
            pos += transform.forward * speed * Time.deltaTime * breakFactor;
            pos.y = pos.y <= 0.15f ? 0.15f : pos.y; 
            transform.position = pos;

            
        }
        else // at this point, target is reached
        {
            if(targetTransform != null){
                // stop flying. Start pecking animation in future
                if (targetTransform.GetComponent<Seed>() != null)
                {
                    Peck();
                    // drop key if grabbed
                    if(claws.childCount > 0)
                        Drop();
                    return;
                }

                // destroy the targets rigidbody to prevent it from falling down
                if (targetTransform.GetComponent<Rigidbody>() != null)
                {
                    Destroy(targetTransform.GetComponent<Rigidbody>());
                }

                // if target was key, destroy the key finder component
                if(targetTransform.CompareTag("Key")){
                    Destroy(GetComponent<BirdKeyFinder>());
                    // snap target transform to the claws
                    targetTransform.position = claws.position;
                    targetTransform.parent = claws;
                    targetTransform = null;
                }
                // start idle routine
                GoIdle();
            }else{
                // start idle routine
                GoIdle();
            }
        }
    }

    private Vector3 Steer(Vector3 target, float maxVelocity){
        var desiredVelocity = target - transform.position;
        var distance = desiredVelocity.magnitude;
        desiredVelocity = Vector3.Normalize(desiredVelocity) * maxVelocity;
        return desiredVelocity - transform.forward;
    }

    public void ChangeTarget(Vector3 target)
    {
        this.target = target;
    }

    public void SetPickUpTarget(Transform target)
    {
        if(claws.Find(target.name) == target)
            return;

        targetTransform = target;
    }

    public void Peck()
    {
        // play pecking animation
        isPecking = !isPecking;
        if (isPecking)
        {
            Invoke(nameof(Peck), peckingTime);
        }
        else
        {
            if (targetTransform != null)
                Destroy(targetTransform.gameObject);

            GoIdle();
        }
    }

    public void Drop(){
        var obj = claws.GetChild(0);
        obj.parent = claws.parent.parent;
        obj.gameObject.AddComponent<Rigidbody>();
    }

    private void OnSeasonUpdate(Season season)
    {
        if (flyingSeasons.Contains(season))
        {
            GoIdle();
        }
        else
        {
            ChangeTarget(south.position);
        }
    }

    public void GoIdle()
    {
        targetTransform = null;
        ChangeTarget(gatheringPosition.position + new Vector3(Random.Range(0.25f, 2f), 0, Random.Range(0.25f, 2f)));
    }

    public Transform GetSouthPosition(){
        return south.transform;
    }
}
