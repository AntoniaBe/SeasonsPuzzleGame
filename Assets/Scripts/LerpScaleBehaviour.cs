using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScaleBehaviour : LerpProperty
{
    [SerializeField]
    private float minFactor;

    private Vector3 min;
    private Vector3 max;
    private bool direction = true;

    private void Start()
    {
        min = Vector3.one * minFactor;
        max = Vector3.one;
        Debug.Log(min + ", " + max);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Lerp();
        }
    }

    public void Lerp()
    {
        direction = !direction;
        Lerp(direction);
    }

    protected override void OnLerp(float t)
    {
        transform.localScale = Vector3.Lerp(min, max, t);
    }

    protected override void OnLerpFinished(float t)
    {
        Debug.Log(t);
    }
}
