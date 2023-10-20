using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // Stores a reference to a waypoint system this object will use
    [SerializeField] private waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float rotateSpeed = 4f;

    [SerializeField] private float distanceThershold = 0.1f;

    // The current waypoint the target that the object is moving towards
    private Transform currentWaypoint;


    //Rotation target
    private Quaternion roationGoal;
    //Direction to next waypoint
    private Vector3 directionToWaypoint;



    // Start is called before the first frame update
    void Start()
    {
        // Set initial position to first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThershold) {

            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            //transform.LookAt(currentWaypoint);

        }
        RotateTowardsWaypoint();
    }

    //Slow rotate
    private void RotateTowardsWaypoint() {

        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        roationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, roationGoal, rotateSpeed * Time.deltaTime);
    }
}
