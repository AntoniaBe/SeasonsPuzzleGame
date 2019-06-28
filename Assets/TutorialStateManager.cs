using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStateManager : MonoBehaviour
{
    private SeasonsManager seasonsManager;
    public GrabbableSeasonStone springStone;
    public GrabbableSeasonStone summerStone;
    public GrabbableSeasonStone autumnStone;
    public GrabbableSeasonStone winterStone;

    void Awake()
    {
        seasonsManager = SeasonsManager.Instance;

        summerStone.IsGrabbable = false;
        springStone.IsGrabbable = false;
        autumnStone.IsGrabbable = false;
        winterStone.IsGrabbable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        seasonsManager.CurrentSeason = Season.WINTER;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
