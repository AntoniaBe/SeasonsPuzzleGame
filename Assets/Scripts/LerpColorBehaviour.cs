using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColorBehaviour : LerpProperty
{
    [SerializeField]
    private Color mainColor = Color.black;

    [SerializeField]
    private Color targetColor = Color.white;

    [SerializeField]
    private Renderer targetRenderer = null;

    protected override void OnLerp(float t)
    {
        targetRenderer.material.color = Color.Lerp(mainColor, targetColor, t);
    }

    protected override void OnLerpFinished(float t)
    {
        targetRenderer.material.color = Color.Lerp(mainColor, targetColor, t);
    }
}
