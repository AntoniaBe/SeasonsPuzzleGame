using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public bool hasSpringStone;
    public bool hasSummerStone;
    public bool hasAutumnStone;
    public bool hasWinterStone;

    private void Awake()
    {
        hasSpringStone = hasSummerStone = hasAutumnStone = hasWinterStone = false;
    }
}
