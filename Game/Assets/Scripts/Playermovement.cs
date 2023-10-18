using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    //natáčení po x, z o 7.5 stupně
    public float speed = 5f;
    private float right_left_Input;
    private float forward_backward_Input;
    private bool fall_Input;
    private bool respawn = false;

    private Vector2 tilt;

    private Vector2 turn; //.x = x // .y = z
    public float mouse_sens = 5f;
    private bool jump_Input;

    float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        right_left_Input = Input.GetAxis("Vertical");
        forward_backward_Input = Input.GetAxis("Horizontal");
        fall_Input = Input.GetKey(KeyCode.LeftShift);
        jump_Input = Input.GetKey(KeyCode.Space);
        Debug.Log(right_left_Input + " " + forward_backward_Input + " " + tilt.x + " " + tilt.y);
        if(right_left_Input > 0)
        {
            tilt.x = -7.5f;
        }
        else if(right_left_Input < 0)
        {
            tilt.x = 7.5f;
        }
        else
        {
            tilt.x = 0f;
        }

        if(forward_backward_Input > 0)
        {
            tilt.y = -7.5f;
        }
        else if(forward_backward_Input < 0)
        {
            tilt.y = 7.5f;
        }
        else
        {
            tilt.y = 0f;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(tilt.y,turn.x,tilt.x),(timeCount*0.01f));
        transform.Translate(Vector3.right * Time.deltaTime * speed * right_left_Input);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -forward_backward_Input);

        if(fall_Input)
        {
            transform.Translate(Vector3.up * Time.deltaTime * -speed);
        }

        turn.x += (Input.GetAxis("Mouse X") * mouse_sens);
        // transform.localRotation = Quaternion.Euler(0, turn.x,0);
 
        if(jump_Input)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        respawn = Input.GetKey(KeyCode.R);

        if(respawn)
        {
            transform.position = new Vector3(0,1,0);
        }
        timeCount = timeCount + Time.deltaTime;
    }
}