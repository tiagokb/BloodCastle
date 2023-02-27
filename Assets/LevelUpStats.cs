using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEditor.TestTools.CodeCoverage;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{

    public int level = 1;
    public float experience { get; private set; }

    public TMP_Text lvlText;
    public Image expBarImage;

    private float expBarAmount;

    private void Start()
    {
        UpdateUi();
    }

    public static int ExpNeedToLvlUp (int currentLevel)
    {
        if (currentLevel == 0)
        {
            return 0;
        }

        return (currentLevel * currentLevel + currentLevel) * 5;
    }
    public void SetExperience(float exp)
    {

        experience += exp;

        float expNeeded = ExpNeedToLvlUp(level);
        float previousExperience = ExpNeedToLvlUp(level - 1);

        // Level up with exp
        if (experience >= expNeeded)
        {
            LevelUp();
            expNeeded = ExpNeedToLvlUp(level);
            previousExperience = ExpNeedToLvlUp(level - 1);
        }

        expBarAmount = (experience - previousExperience) / (expNeeded - previousExperience);

        UpdateUi();
    }

    public void UpdateUi()
    {

        // Fill exp bar image with exp

        expBarImage.fillAmount = expBarAmount;

        if (expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }

        lvlText.text = level.ToString();
    }

    public void LevelUp()
    {
        //TODO: Increse the stats of the player, give him a new hability and give some points to distribute.

        level++;
    }
}
