using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{

    public float tauntArea;

    private void Start()
    {
        setAtkSpeed(3f);
    }
}
