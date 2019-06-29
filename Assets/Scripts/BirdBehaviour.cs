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

    private Animator animator;
    private Vector3 target;

    [SerializeField]
    private Season[] flyingSeasons;

    [SerializeField]
    private Transform south;
    [SerializeField]
    private Transform gatheringPosition;

    void Awake()
    {
        SeasonsManager.Instance.UpdateSeasonEvent.AddListener(OnSeasonUpdate);
    }

    private void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("Flying", true);
    }

    private void Update()
    {
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
            var newTarget = transform.position + new Vector3(Random.Range(-1, 2f), 0, Random.Range(-1, 2f));
            Debug.Log(newTarget);
            ChangeTarget(newTarget);
        }
    }

    public void ChangeTarget(Vector3 target)
    {
        this.target = target;
    }

    private void OnSeasonUpdate(Season season)
    {
        if (flyingSeasons.Contains(season))
        {
            ChangeTarget(gatheringPosition.position);
        }
        else
        {
            ChangeTarget(south.position);
        }
    }
}
