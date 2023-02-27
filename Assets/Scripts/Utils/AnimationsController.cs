using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class AnimationsController : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        animator= GetComponent<Animator>();
    }

    public void animateFloat(string animatorParams, float value)
    {
        animator.SetFloat(animatorParams, value);
    }

    internal void animateFloat(string animatorParams, float value, float motionSmoothTime)
    {
        animator.SetFloat(animatorParams, value, motionSmoothTime, Time.deltaTime);
    }

    internal void animateBool(string animatorParams, bool value)
    {
        animator.SetBool(animatorParams, value);
    }

    internal void animateTrigger(string animatorParams)
    {
        animator.SetTrigger(animatorParams);
    }

    
}
