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

        if (gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().material = highLightMaterial;
        } else if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = highLightMaterial;
        }
    }

    private void OnMouseExit()
    {

        if (gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
        else if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = defaultMaterial;
        }
    }
}
