using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoutUI : MonoBehaviour
{
    protected double speedPercentage = 100;
    [SerializeField] protected TextMeshProUGUI throttlePercentage;
    [SerializeField] private WaypointMover Currentspeed;
    [SerializeField] private RawImage crosshairTrack;
    [SerializeField] protected TextMeshProUGUI warning;
    [SerializeField] private TextMeshProUGUI track;
    [SerializeField] private DetectTarget isON;
    [SerializeField] private GameObject cam;
    private float timer;

private void Start() {
    
    crosshairTrack.enabled = false;
}

private void Update() {
    if (cam.activeSelf) {
        throttlePercentage.text = "THROTTLE: " + speedPercentage + "%";

        if (Input.GetKey(KeyCode.LeftShift)) {

            if (Currentspeed.moveSpeedMax < 20f) {

                Currentspeed.moveSpeedMax += 0.01f;
            }
        }
        
        if (Input.GetKey(KeyCode.LeftControl)) {

            if(Currentspeed.moveSpeedMax > 9f) {

                Currentspeed.moveSpeedMax -= 0.01f;
            }
        }

        speedPercentage = Math.Round((Currentspeed.moveSpeedMax * 100f) / 20f);

        if (speedPercentage == 45d) {
            timer = timer + Time.deltaTime;
          if(timer >= 0.4)
          {
                  warning.enabled = true;
          }
          if(timer >= 1)
          {
                  warning.enabled = false;
                  timer = 0;   
            } 
        } else {
            warning.enabled = false;
            }

        if (isON.track) {
            track.text = "ON";
            timer = timer + Time.deltaTime;
          if(timer >= 1)
          {
                  track.enabled = true;
          }
          if(timer >= 2)
          {
                  track.enabled = false;
                  timer = 0;   
            } 
        } else {
            track.text = "";
            }
        }
    }
}
