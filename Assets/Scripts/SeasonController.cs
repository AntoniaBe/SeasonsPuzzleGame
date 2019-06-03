using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SeasonController : MonoBehaviour
{
    [SerializeField]
    private float touchSwipeThreshold = 1.0f;

    private VRTK_ControllerEvents controllerEvents;
    private float startTouchX;
    private float lastTouchX;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
    }

    private void Start()
    {
        controllerEvents.TouchpadTouchStart += new ControllerInteractionEventHandler(TouchStart);
        controllerEvents.TouchpadTouchEnd += new ControllerInteractionEventHandler(TouchEnd);

    }

    private void Update()
    {
        if (GetComponent<VRTK_ControllerEvents>().touchpadTouched)
            lastTouchX = controllerEvents.GetAxis(VRTK_ControllerEvents.Vector2AxisAlias.Touchpad).x;
    }

    private void TouchStart(object sender, ControllerInteractionEventArgs e)
    {
        startTouchX = e.touchpadAxis.x;
    }

    private void TouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        if (Mathf.Abs(startTouchX - lastTouchX) < touchSwipeThreshold)
            return;

        if (startTouchX > lastTouchX)
            SeasonsManager.Instance.ChangeSeasonBackwards();
        else
            SeasonsManager.Instance.ChangeSeasonForwards();

        Debug.Log(SeasonsManager.Instance.GetCurrentSeason());
    }
}
