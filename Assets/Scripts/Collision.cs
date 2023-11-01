using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Playermovement trottle;
    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        Debug.Log("collision");
        if(trottle.thrust <= 0)
        {
            player.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if(trottle.thrust > 0)
        {
            player.constraints = RigidbodyConstraints.None;
        }
    }
}
