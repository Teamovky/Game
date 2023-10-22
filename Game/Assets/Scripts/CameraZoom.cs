using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

//Zooms camera
public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public GameObject obj;
    public float zoomSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        if (obj.activeSelf) {
            if(Input.GetKey(KeyCode.Z)) {
                    cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 15f, zoomSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.X)) {
                cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 60f, zoomSpeed * Time.deltaTime);
            }
        }
    }
}
