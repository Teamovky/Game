using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DetectTarget : MonoBehaviour
{

    public GameObject target;
    public Camera cam;
    public bool track = false;
    [SerializeField] private RawImage crosshair;
    [SerializeReference] private RawImage crosshairTrack;

    void Start()
    {
        crosshair.enabled = true;
        crosshairTrack.enabled = false;
    }

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point)< 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update ()
    {
        
        if (IsVisible(cam,target) && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("TARGET LOCKED");
            track = true;
            crosshair.enabled = false;
            crosshairTrack.enabled = true;
        }
        
        
    
        if (Input.GetKey(KeyCode.Escape) && track) {
            track = false;
            crosshair.enabled = true;
            crosshairTrack.enabled = false;
        }
    }
}
