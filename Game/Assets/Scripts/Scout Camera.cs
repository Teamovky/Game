using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scout drone sphere rotation
public class ScoutCamera : MonoBehaviour
{
    private Vector2 turn;
    public GameObject cam2;
    [SerializeField] private DetectTarget isON;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.activeSelf && isON.track == false) {
            turn.x += Input.GetAxis("Mouse X");
            transform.localRotation = Quaternion.Euler(0,0,turn.x);
        }
    }
}