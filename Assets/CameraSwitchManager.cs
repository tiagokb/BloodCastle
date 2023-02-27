using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchManager : MonoBehaviour
{

    public CameraBehavior cameraBehavior;
    public CameraRoam cameraRoam;

    bool camViewChanged = false;

    // Start is called before the first frame update
    void Start()
    {

        cameraRoam.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {

        
        
        if (camViewChanged) {
        
            if (Input.GetKeyDown(KeyCode.Y))
            {

                camViewChanged = false;
                cameraRoam.enabled= false;
                cameraBehavior.enabled = true;
            } 
        } else
        {

            if (Input.GetKeyDown(KeyCode.Y))
            {

                cameraBehavior.enabled = false;

                cameraRoam.enabled = true;
                camViewChanged = true;
            }
        }
    }
}
