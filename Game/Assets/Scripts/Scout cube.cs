using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scout drone cube rotation, rotation angle limitation
public class ScoutSphere : MonoBehaviour
{
    private Vector2 turn;
    public GameObject cam2;
    public GameObject cube;
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
            turn.y -= Input.GetAxis("Mouse Y");
            if (turn.y < -25f) {
                turn.y = -25f;
            }

            if (turn.y > 180f) {
                turn.y = 180f;
            }

            transform.localRotation = Quaternion.Euler(Mathf.Clamp(turn.y,-25f,180f),0,0);
        }
    }
}
