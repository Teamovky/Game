using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrotation : MonoBehaviour
{
    protected Vector2 turn;
    public float mouse_sens = 5f;
    private float mousey;
    public GameObject cam1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam1.activeSelf) {
            turn.y += (Input.GetAxis("Mouse Y") * mouse_sens);
            turn.y = Mathf.Clamp(turn.y,-90,90);

            transform.localRotation = Quaternion.Euler(-turn.y, 90,0);
        }
    }
        
}
