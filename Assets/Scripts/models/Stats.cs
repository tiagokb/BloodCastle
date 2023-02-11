using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public int life;
    public int defense;
    public int attack;

    /*
     The minimium atk speed multiplier = 0.5
     The maximum atk speed multiplier = 2.3 
     */
    private float atkSpeed = 0.5f;

    public void setAtkSpeed(float atkSpeed)
    {
        this.atkSpeed = atkSpeed;
    }

    public float getAtkSpeed()
    {
        if (this.atkSpeed < 0.5)
        {
            return 0.5f;
        }
        else if (this.atkSpeed > 2.3)
        {
            return 2.3f;
        }
        else return this.atkSpeed;
    }

    public float range;
}
