using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GrabbableEvent : UnityEvent<GrabbableSeasonStone>
{
}

public class TutorialStateManager : Singleton<TutorialStateManager>
{
    private SeasonsManager seasonsManager;
    public GrabbableSeasonStone springStone;
    public GrabbableSeasonStone summerStone;
    public GrabbableSeasonStone autumnStone;
    public GrabbableSeasonStone winterStone;

    public UnityEvent<GrabbableSeasonStone> OnStoneTaken;

    void Awake()
    {
        seasonsManager = SeasonsManager.Instance;
        OnStoneTaken = new GrabbableEvent();
        OnStoneTaken.AddListener(StoneTaken);
    }

    private void Start(){
        summerStone.IsGrabbable = false;
        springStone.IsGrabbable = false;
        autumnStone.IsGrabbable = false;
        winterStone.IsGrabbable = true;

        seasonsManager.CurrentSeason = Season.WINTER;
    }

    private void StoneTaken(GrabbableSeasonStone stone)
    {
        if(stone.season == Season.WINTER){
            //TODO color center
        }
    }
}
