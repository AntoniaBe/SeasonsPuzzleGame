using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SeasonController : MonoBehaviour
{
    [SerializeField]
    private float touchSwipeThreshold = 1.0f;
    public Player player;

    private VRTK_ControllerEvents controllerEvents;
    private float startTouchX;
    private float lastTouchX;

    private Dictionary<Season, GameObject> seasonStones;
    private int degreesLeftOfSeasonStoneRotation;
    private int degreesPerFixedFrameOfSeasonStoneRotation;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        seasonStones = new Dictionary<Season, GameObject>();
        degreesPerFixedFrameOfSeasonStoneRotation = 2;
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

    private void FixedUpdate()
    {
        if (degreesLeftOfSeasonStoneRotation > 0)
        {
            foreach (KeyValuePair<Season, GameObject> entry in seasonStones)
            {
                // rotate around the local z axis to world vector one degree
                entry.Value.transform.RotateAround(this.transform.position, this.transform.TransformDirection(Vector3.forward), degreesPerFixedFrameOfSeasonStoneRotation);
            }

            degreesLeftOfSeasonStoneRotation -= Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);
        }
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
                RotateSeasonStonesInDegrees(90);
                SeasonsManager.Instance.ChangeSeasonBackwards();
            }
        }
        else if (startTouchX < lastTouchX)
        {
            Season nextSeason = SeasonsManager.Instance.NextSeason;

            if (player.CanChangeToSeason(nextSeason))
            {
                RotateSeasonStonesInDegrees(-90);
                SeasonsManager.Instance.ChangeSeasonForwards();
            }
        }

        Debug.Log(SeasonsManager.Instance.CurrentSeason);
    }

    public void AttachSeasonStone(GrabbableSeasonStone seasonStone)
    {
        seasonStones.Add(seasonStone.season, seasonStone.gameObject);
        player.SetSeasonPower(seasonStone.season, true);
        PutSeasonStoneOnController(seasonStone);
    }

    private void PutSeasonStoneOnController(GrabbableSeasonStone seasonStone)
    {
        GameObject seasonStoneGameObject = seasonStone.gameObject;
        seasonStoneGameObject.transform.parent = this.gameObject.transform;
        seasonStoneGameObject.transform.localPosition = new Vector3(0, 0.1f, 0);

        int rotation = 0;

        if (SeasonsManager.Instance.NextSeason == seasonStone.season)
            rotation = 90;
        else if (SeasonsManager.Instance.PreviousSeason == seasonStone.season)
            rotation = -90;
        else if (SeasonsManager.Instance.CurrentSeason == seasonStone.season)
            rotation = 0;
        else
            rotation = 180;

        seasonStoneGameObject.transform.RotateAround(this.transform.position, this.transform.TransformDirection(Vector3.forward), rotation);
    }

    private void RotateSeasonStonesInDegrees(int degrees)
    {
        if (degrees < 0)
            degreesPerFixedFrameOfSeasonStoneRotation = -Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);
        else
            degreesPerFixedFrameOfSeasonStoneRotation = Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);

        degreesLeftOfSeasonStoneRotation = Mathf.Abs(degrees);
    }
}
