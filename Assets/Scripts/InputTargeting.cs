using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{

    public GameObject Player;
    public bool heroPlayer;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {

                if (hit.collider.gameObject.GetComponent<Targetable>() != null)
                { 
                    Player.GetComponent<PlayerControll>().Target = hit.collider.gameObject;

                } else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
                {
                    Player.GetComponent<PlayerControll>().Target = null;
                }
            }
        }
    }
}
