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
    public GameObject key;
    private SeasonsManager seasonsManager;
    public GrabbableSeasonStone springStone;
    public GrabbableSeasonStone summerStone;
    public GrabbableSeasonStone autumnStone;
    public GrabbableSeasonStone winterStone;

    public GameObject arrow;
    private GameObject bird;
    public UnityEvent<GrabbableSeasonStone> OnStoneTaken;
    private bool tutorialDone = false;
    public SoundManager soundManager;


    [SerializeField] 
    ScaleGrayAreas grayManager;

    private int sectorsEnabled = 0;

    void Awake()
    {
        seasonsManager = SeasonsManager.Instance;
        OnStoneTaken = new GrabbableEvent();
        OnStoneTaken.AddListener(StoneTaken);
        seasonsManager.UpdateSeasonEvent.AddListener(OnSeasonUpdate);
    }

    private void Start(){
        // set initial values for interactable objects
        summerStone.IsGrabbable = false;
        springStone.IsGrabbable = false;
        autumnStone.IsGrabbable = false;
        winterStone.IsGrabbable = true;

        arrow.SetActive(false);
        springStone.gameObject.SetActive(false);
        summerStone.gameObject.SetActive(false);
        autumnStone.gameObject.SetActive(false);

        bird = GameObject.FindGameObjectWithTag("Bird");
        if (bird == null) 
            Debug.LogError("No GameObject with \"Bird found\"");

        seasonsManager.CurrentSeason = Season.WINTER;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            grayManager.enableSector(sectorsEnabled);
            sectorsEnabled++;
        }
    }

#endif

    private void StoneTaken(GrabbableSeasonStone stone)
    {
        // changes world and object states according the the grabbed season stone
        if(stone.season == Season.WINTER){
            soundManager.PlaySuccessClip();
            grayManager.enableSector(0);
            springStone.gameObject.SetActive(true);
            summerStone.gameObject.SetActive(true);
        }

        if(stone.season == Season.SPRING){
            arrow.SetActive(true);
        }

        if(stone.season == Season.SUMMER)
        {
            autumnStone.gameObject.SetActive(true);
        }

        if(stone.season == Season.AUTUMN)
        {
            grayManager.enableSector(1);
            tutorialDone = true;
            soundManager.PlaySuccessClip();
        }
    }

    public void ChestOpen()
    {
        grayManager.enableSector(2);
        soundManager.PlaySuccessClip();
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
    }

    public bool TutorialDone(){
        return tutorialDone;
    }
}
