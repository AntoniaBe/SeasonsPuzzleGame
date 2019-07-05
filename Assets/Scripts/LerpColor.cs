using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : LerpProperty
{
    private Renderer rend;
    private Color target;
    private Color start;

    private void Start(){
        rend = GetComponent<Renderer>();
    }
    public void StartLerp(Color target)
    {
        this.target = target;
        start = rend.material.color;
        Lerp(false);
    }

    protected override void OnLerp(float t)
    {
        var color = Color.Lerp(start, target, t);
        rend.material.color = color;
    }

    protected override void OnLerpFinished(float t)
    {
        var color = Color.Lerp(start, target, t);
        rend.material.color = color;
    }
}
