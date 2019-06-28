using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LerpProperty : MonoBehaviour
{
    [SerializeField]
    private float duration = 4.0f;

    protected float lerpTime;
    protected float progress;
    protected bool dir;

    private void Start()
    {
        lerpTime = duration;
    }

    public void Lerp(bool inOut)
    {
        dir = !inOut;
        Animate();
    }

    protected IEnumerator LerpCoroutine()
    {
        while (lerpTime < duration)
        {
            yield return null;
            lerpTime += Time.deltaTime;
            float t = lerpTime / duration;
            OnLerp((dir == true) ? t : 1 - t);
        }

        lerpTime = duration;
        OnLerpFinished((dir == true) ? 1 : 0);
    }

    protected void Animate()
    {
        progress = duration - lerpTime;
        lerpTime = progress;
        StopCoroutine("LerpCoroutine");
        StartCoroutine("LerpCoroutine");
    }

    abstract protected void OnLerp(float t);

    abstract protected void OnLerpFinished(float t);

}
