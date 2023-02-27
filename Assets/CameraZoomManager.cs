using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomManager : MonoBehaviour
{

    public float zoomSpeed;

    private float camFov;
    private float mouseScrollInput;

    // Start is called before the first frame update
    void Start()
    {
        camFov = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //camera zoom in and out
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        camFov -= mouseScrollInput * zoomSpeed;
        camFov = Mathf.Clamp(camFov, 30, 60);

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, camFov, zoomSpeed);
    }
}
