using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : ScriptableObject
{

    public new string name;
    public Sprite icon;
    public AbilityTypes type;
    public float cooldownTime;
    public float activeTime;

    public virtual void OnReady(GameObject parent) { }

    public virtual void OnActive(GameObject parent) { }

    public virtual void OnCooldown(GameObject parent) { }
}
