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
    private float startTouchpadAxisAngle;
    private float lastTouchPadAxisAngle;
    private Vector2 startTouchpadAxisVector;
    private Vector2 lastTouchpadAxisVector;
    private bool seasonChangedInSingleTouch;

    private Dictionary<Season, GameObject> seasonStones;
    private int degreesLeftOfSeasonStoneRotation;
    private int degreesPerFixedFrameOfSeasonStoneRotation;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        seasonStones = new Dictionary<Season, GameObject>();
        degreesPerFixedFrameOfSeasonStoneRotation = 2;
        seasonChangedInSingleTouch = false;
    }

    private void Start()
    {
        controllerEvents.TouchpadTouchStart += new ControllerInteractionEventHandler(TouchStart);
        controllerEvents.TouchpadTouchEnd += new ControllerInteractionEventHandler(TouchEnd);
        // controllerEvents.TouchpadTo += new ControllerInteractionEventHandler(Touch);
    }

    private void Update()
    {
        if (GetComponent<VRTK_ControllerEvents>().touchpadTouched)
        {
            float totalAngle = Vector2.SignedAngle(controllerEvents.GetTouchpadAxis(), startTouchpadAxisVector);

            // Debug.Log(totalAngle);

            if (!seasonChangedInSingleTouch)
            {
                if (totalAngle < -170)
                {
                    Season nextSeason = SeasonsManager.Instance.NextSeason;

                    if (player.CanChangeToSeason(nextSeason))
                    {
                        RotateSeasonStonesInDegrees(-90);
                        SeasonsManager.Instance.ChangeSeasonForwards();
                    }

                    seasonChangedInSingleTouch = true;
                }
                else if (totalAngle > 170)
                {
                    Season previousSeason = SeasonsManager.Instance.PreviousSeason;

                    if (player.CanChangeToSeason(previousSeason))
                    {
                        RotateSeasonStonesInDegrees(90);
                        SeasonsManager.Instance.ChangeSeasonBackwards();
                    }

                    seasonChangedInSingleTouch = true;
                }
            }
}
            
    }

    private void FixedUpdate()
    {
        if (degreesLeftOfSeasonStoneRotation > 0)
        {
            Vector3 rotationCenterPosition = this.transform.position + this.transform.TransformDirection(new Vector3(0, 0.05f, -0.05f));

            foreach (KeyValuePair<Season, GameObject> entry in seasonStones)
            {
                // rotate around the local z axis to world vector one degree
                entry.Value.transform.RotateAround(rotationCenterPosition, this.transform.TransformDirection(Vector3.up), degreesPerFixedFrameOfSeasonStoneRotation);
            }

            degreesLeftOfSeasonStoneRotation -= Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);
        }
    }

    private void TouchStart(object sender, ControllerInteractionEventArgs e)
    {
        startTouchX = e.touchpadAxis.x;
        startTouchpadAxisAngle = e.touchpadAngle;
        lastTouchPadAxisAngle = startTouchpadAxisAngle;
        startTouchpadAxisVector = e.touchpadAxis;
        lastTouchpadAxisVector = startTouchpadAxisVector;
    }

    private void TouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        seasonChangedInSingleTouch = false;
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
        seasonStoneGameObject.transform.localPosition = new Vector3(0, 0.04f, 0);

        Vector3 rotationCenterPosition = this.transform.position + this.transform.TransformDirection(new Vector3(0, 0.04f, -0.05f));

        ChangeSeasonStoneScale(seasonStoneGameObject);

        int rotation = 0;

        if (SeasonsManager.Instance.NextSeason == seasonStone.season)
            rotation = 90;
        else if (SeasonsManager.Instance.PreviousSeason == seasonStone.season)
            rotation = -90;
        else if (SeasonsManager.Instance.CurrentSeason == seasonStone.season)
            rotation = 0;
        else
            rotation = 180;

        seasonStoneGameObject.transform.RotateAround(rotationCenterPosition, this.transform.TransformDirection(Vector3.up), rotation);
    }

    private void ChangeSeasonStoneScale(GameObject seasonStoneGameObject)
    {
        seasonStoneGameObject.transform.localScale = seasonStoneGameObject.transform.localScale * 0.5f;
        GameObject glow = seasonStoneGameObject.transform.GetChild(0).gameObject;

        glow.transform.localScale = seasonStoneGameObject.transform.GetChild(0).transform.localScale * 0.5f;

        GameObject central = glow.transform.FindChild("central").gameObject;
        GameObject dust = glow.transform.FindChild("dust").gameObject;
        GameObject energy = glow.transform.FindChild("energy").gameObject;
        GameObject energy_central = glow.transform.FindChild("energy_central").gameObject;
        GameObject smoke = glow.transform.FindChild("smoke").gameObject;

        central.GetComponent<ParticleSystem>().startSize = 2;
        dust.GetComponent<ParticleSystem>().startSize = 0.05f;
        energy.GetComponent<ParticleSystem>().startSize = 3;
        energy_central.GetComponent<ParticleSystem>().startSize = 2;
        smoke.GetComponent<ParticleSystem>().startSize = 0.02f;

        central.GetComponent<ParticleSystem>().startLifetime = 2;
        dust.GetComponent<ParticleSystem>().startLifetime = 0.3f;
        smoke.GetComponent<ParticleSystem>().startLifetime = 0.7f;
    }

    private void RotateSeasonStonesInDegrees(int degrees)
    {
        if (degrees < 0)
            degreesPerFixedFrameOfSeasonStoneRotation = -Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);
        else
            degreesPerFixedFrameOfSeasonStoneRotation = Mathf.Abs(degreesPerFixedFrameOfSeasonStoneRotation);

        degreesLeftOfSeasonStoneRotation += Mathf.Abs(degrees);
    }
}
