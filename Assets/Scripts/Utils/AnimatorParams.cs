using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParams : MonoBehaviour
{

    /*
     Player baselayer
     */
    public static string BASE_LAYER_MOVING = "Moving";
    public static string BASE_LAYER_ATTACKING = "Attacking";
    public static string BASE_LAYER_ATK_SPEED = "AtkSpeed";
    public static string BASE_LAYER_DIE = "Die";

    /*
     Golem enemy baselayer
     */
    public static string GOLEM_BASE_LAYER_WALK = "Walk";
    public static string GOLEM_BASE_LAYER_HIT = "Hit";
    public static string GOLEM_BASE_LAYER_RAGE = "Rage";
}
