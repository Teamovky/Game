using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    //natáčení po x, z o 7.5 stupně

    Rigidbody player;
    private float right_left_Input;
    private float forward_backward_Input;
    private bool fall_Input;
    private Vector2 tilt;
    private Vector2 turn; //.x = x // .y = z
    public float mouse_sens = 5f;
    private bool jump_Input;
    private float timeCount = 0.0f;
    public float speed = .25f;
    public float thrust = 0f;

    public GameObject cam1;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //m_Rigidbody.AddForce(transform.up * m_Thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cam1.activeSelf) 
        {
            right_left_Input = Input.GetAxis("Horizontal");
            forward_backward_Input = Input.GetAxis("Vertical");
            fall_Input = Input.GetKey(KeyCode.LeftShift);
            jump_Input = Input.GetKey(KeyCode.Space);
            //Debug.Log("R+L " + right_left_Input + " F+B " + forward_backward_Input + " Tilt Y " + tilt.x + " Tilt X " + tilt.y);

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

            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(tilt.y,turn.x,tilt.x),(timeCount*speed));
            transform.Translate(Vector3.right * timeCount * speed * right_left_Input);
            transform.Translate(Vector3.forward * timeCount * speed * -forward_backward_Input);
            //Debug.Log(timeCount);

            if(fall_Input && thrust >= -10)
            {
                thrust -= 5f * Time.deltaTime;
            }

            turn.x += (Input.GetAxis("Mouse X") * mouse_sens);
            // transform.localRotation = Quaternion.Euler(0, turn.x,0);
    
            if(jump_Input && thrust <= 10)
            {
                thrust += 5f * Time.deltaTime;
            }

            if(thrust < -1 || thrust > 1)
            {
                player.AddForce(Vector3.up * thrust);
            }

            //Debug.Log(thrust);

            timeCount = timeCount + Time.deltaTime;
        }
    }
}