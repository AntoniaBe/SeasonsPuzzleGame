﻿using System.Collections;
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
    public Player player;
    private Dictionary<Season, GameObject> seasonStones;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        seasonStones = new Dictionary<Season, GameObject>();
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
        {
            Season previousSeason = SeasonsManager.Instance.PreviousSeason;

            if (player.CanChangeToSeason(previousSeason))
            {
                SeasonsManager.Instance.ChangeSeasonBackwards();
            }
        }
        else if (startTouchX < lastTouchX)
        {
            Season nextSeason = SeasonsManager.Instance.NextSeason;

            if (player.CanChangeToSeason(nextSeason))
            {
                SeasonsManager.Instance.ChangeSeasonForwards();
            }
        }

        Debug.Log(SeasonsManager.Instance.CurrentSeason);
    }

    public void AttachSeasonStone(GrabbableSeasonStone seasonStone)
    {
        Season season = seasonStone.season;
        seasonStones.Add(season, seasonStone.gameObject);
        PutSeasonStoneOnController(seasonStone.gameObject);
    }

    private void PutSeasonStoneOnController(GameObject seasonStoneGameObject)
    {
        seasonStoneGameObject.transform.parent = this.gameObject.transform;
        seasonStoneGameObject.transform.localPosition = new Vector3(0, 0.1f, 0);
    }
}
