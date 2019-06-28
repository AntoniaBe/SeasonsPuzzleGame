using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GrabbableEvent : UnityEvent<GrabbableSeasonStone>
{
}

public class StateManager : Singleton<StateManager>
{
    private SeasonsManager seasonsManager;
    public GrabbableSeasonStone springStone;
    public GrabbableSeasonStone summerStone;
    public GrabbableSeasonStone autumnStone;
    public GrabbableSeasonStone winterStone;
    private GameObject bird;
    public UnityEvent<GrabbableSeasonStone> OnStoneTaken;
    private bool tutorialDone;

    void Awake()
    {
        seasonsManager = SeasonsManager.Instance;
        OnStoneTaken = new GrabbableEvent();
        OnStoneTaken.AddListener(StoneTaken);

        seasonsManager.UpdateSeasonEvent.AddListener(OnSeasonUpdate);
    }

    private void Start(){
        summerStone.IsGrabbable = false;
        springStone.IsGrabbable = false;
        autumnStone.IsGrabbable = false;
        winterStone.IsGrabbable = true;

        springStone.gameObject.SetActive(false);
        summerStone.gameObject.SetActive(false);
        autumnStone.gameObject.SetActive(false);

        bird = GameObject.FindGameObjectWithTag("Bird");
        if (bird == null) Debug.LogError("No GameObject with \"Bird found\"");

        seasonsManager.CurrentSeason = Season.WINTER;
    }

    private void StoneTaken(GrabbableSeasonStone stone)
    {
        if(stone.season == Season.WINTER){
            //TODO color center
            springStone.gameObject.SetActive(true);
            summerStone.gameObject.SetActive(true);
        }

        if(stone.season == Season.SUMMER)
        {
            autumnStone.gameObject.SetActive(true);
        }

        if(stone.season == Season.AUTUMN)
            //TODO color first sector
            Debug.Log("TODO");
            tutorialDone = true;
    }

    private void OnSeasonUpdate(Season season)
    {
        if(!summerStone.IsTaken)
            summerStone.IsGrabbable = (season != Season.WINTER);

        if(!autumnStone.IsTaken)
            autumnStone.IsGrabbable = (season == Season.SUMMER);

        if (tutorialDone && season != Season.WINTER && season != Season.AUTUMN)
        {
            bird.SetActive(true);
        }
        else
        {
            // bird.SetActive(false);
        }
    }
}
