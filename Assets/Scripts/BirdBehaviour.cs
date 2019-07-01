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
        isPecking = false;
    }

    private void Update()
    {
        // if (Time.time - startPeckingTime < peckingTime && isPecking)
        //     return;

        // isPecking = false;
        if (isPecking)
            return;

        if(targetTransform != null && target != south.position)
            target = targetTransform.position;

        if(Vector3.Distance(transform.position, target) > minDist)
        {
            var targetDir = target - transform.position;
            var newDir = Vector3.RotateTowards(transform.forward, targetDir, steeringSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            var pos = transform.position;
            pos += transform.forward * speed * Time.deltaTime;
            transform.position = pos;
            
        }
        else
        {
            if(targetTransform != null){
                if (targetTransform.GetComponent<Seed>() != null)
                {
                    Peck();
                    return;
                }

                if (targetTransform.GetComponent<Rigidbody>() != null)
                {
                    Destroy(targetTransform.GetComponent<Rigidbody>());
                }

                targetTransform.position = claws.position;
                targetTransform.parent = claws;
                targetTransform = null;
                GoIdle();
            }else{
                var newDir = transform.forward * 2 + transform.right * Random.Range(0.5f, 2f);
                newDir.y = 0;
                ChangeTarget(transform.position + newDir);
            }
        }
    }

    public void ChangeTarget(Vector3 target)
    {
        this.target = target;
    }

    public void PickUp(Transform target)
    {
        //TODO Disable potential rigidbody
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
            targetTransform = null;
            GoIdle();
        }
        // startPeckingTime = Time.time;
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

    private void GoIdle()
    {
        ChangeTarget(gatheringPosition.position + new Vector3(Random.Range(0.25f, 2f), 0, Random.Range(0.25f, 2f)));
    }
}
