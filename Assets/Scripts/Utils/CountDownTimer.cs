using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public interface IOnFinish
{
    void OnFinish();
}

public class CountDownTimer : MonoBehaviour
{


    float timer = 10f;
    IOnFinish onFinish = null;

    void Update()
    {

        if (onFinish != null)
        {
            OnCountDownFinish(timer!, onFinish);
        }
    }

    public void setConditions(float timer, IOnFinish onFinish)
    {
        this.timer = timer;
        this.onFinish = onFinish;
    }

    public void OnCountDownFinish(float countDownTime, IOnFinish onFinish)
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            onFinish.OnFinish();
        }
    }
}
