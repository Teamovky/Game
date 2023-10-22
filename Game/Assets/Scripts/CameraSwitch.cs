using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

//Switches camera view
public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void Update() {

        if (Input.GetKey(KeyCode.Tab)) {
            Thread.Sleep(100);
            if (cam2.activeSelf) {

                cam1.SetActive(true);
                cam2.SetActive(false);
            } else {

                cam1.SetActive(false);
                cam2.SetActive(true);
            }
        }
    }
}
