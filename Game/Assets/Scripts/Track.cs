using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    
    [SerializeField] private DetectTarget isON;
    public Transform targetObject;
    [SerializeField] private Transform trackCam;
    [SerializeField] private GameObject scoutcam;


    // Update is called once per frame
    void Update()
    {
        if (isON.track && scoutcam.activeSelf) {
            transform.LookAt(targetObject.position);
            trackCam.LookAt(targetObject.position);
        }
    }
}