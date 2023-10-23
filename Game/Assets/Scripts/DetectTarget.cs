using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{

 public GameObject target;
    public Camera cam;

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
        }
    }
    
}

