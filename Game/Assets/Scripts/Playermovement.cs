using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed = 5f;
    private float right_left_Input;
    private float forward_backward_Input;
    private bool fall_Input;
    private Rigidbody player;

    private bool respawn = false;

    private Vector2 turn;
    public float mouse_sens = 5f;
    private float mousex;
    private bool jump_Input;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        right_left_Input = Input.GetAxis("Vertical");
        forward_backward_Input = Input.GetAxis("Horizontal");
        fall_Input = Input.GetKey(KeyCode.LeftShift);
        jump_Input = Input.GetKey(KeyCode.Space);
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * right_left_Input);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -forward_backward_Input);

        if(fall_Input)
        {
            transform.Translate(Vector3.up * Time.deltaTime * -speed);
        }

        turn.x += (Input.GetAxis("Mouse X") * mouse_sens);
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x,0);
 
        if(jump_Input)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        respawn = Input.GetKey(KeyCode.R);

        if(respawn)
        {
            transform.position = new Vector3(0,1,0);
        }
        
    }
}

