using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutSphere : MonoBehaviour
{
    private Vector2 turn;
    public GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.activeSelf) {
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y,0,0);
        }
    }
}
