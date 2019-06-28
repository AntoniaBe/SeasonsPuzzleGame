using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScaleBehaviour : LerpProperty
{
    [SerializeField]
    private float minFactor;

    private Vector3 min;
    private Vector3 max;

    private void Start()
    {
        min = Vector3.one * minFactor;
        max = Vector3.one;
    }

    protected override void OnLerp(float t)
    {
        transform.localScale = Vector3.Lerp(min, max, t);
    }

    protected override void OnLerpFinished(float t)
    {
        transform.localScale = Vector3.Lerp(min, max, t);
    }
}
