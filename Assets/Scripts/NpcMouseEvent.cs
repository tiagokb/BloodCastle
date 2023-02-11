using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NpcMouseEvent : MonoBehaviour
{

    public Material defaultMaterial;
    public Material highLightMaterial;

    private void OnMouseEnter()
    {

        gameObject.GetComponent<MeshRenderer>().material= highLightMaterial;
    }

    private void OnMouseExit()
    {

        gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
