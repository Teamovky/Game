using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scout drone cube rotation, rotation angle limitation
public class ScoutCube : MonoBehaviour
{
    private Vector2 turn;
    public GameObject cam2;
    [SerializeField] private DetectTarget isON;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(180,0,0);
    }

    // Update is called once per frame
    void Update()
    {
       if (cam2.activeSelf && isON.track == false) {
           turn.y -= Input.GetAxis("Mouse Y");
            if (turn.y < 77f) {
                turn.y = 77f;
            }

            if (turn.y > 250f) {
                turn.y = 250f;
            }

            transform.localRotation = Quaternion.Euler(Mathf.Clamp(turn.y,77,250),0,0);
        }
    }
}
