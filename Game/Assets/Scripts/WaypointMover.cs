using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves objects to waypoints, generates random spawn variable, rotates object models on init
public class WaypointMover : MonoBehaviour
{
    // Stores a reference to a waypoint system this object will use
    [SerializeField] private waypoints waypoints;
    [SerializeField] private WaypointsRandom waypointsRandom;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float rotateSpeed = 4f;

    [SerializeField] private float distanceThershold = 0.1f;

    // The current waypoint the target that the object is moving towards
    private Transform currentWaypoint;


    //Rotation target
    private Quaternion roationGoal;
    //Direction to next waypoint
    private Vector3 directionToWaypoint;

     public bool RandomSpawn = true;
    public float startrotationAnglex = 0f;
    public float startrotationAngley = 0f;
    public float startrotationAnglez = 0f;

    [SerializeField] private int NumberOfPaths;
    public int SpawnNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetComponent<MeshRenderer>() != null) {

            transform.GetComponent<MeshRenderer>().enabled = true;
            for (int i = 0; i < transform.childCount; i++) {

                transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
        SpawnNumber = Random.Range(0,NumberOfPaths);
        if (RandomSpawn) {
            //Set initial position to first waypoint
            currentWaypoint = waypointsRandom.GetNextWaypoint(currentWaypoint);
            transform.position = currentWaypoint.position;

            // Set initial position to first waypoint
            currentWaypoint = waypointsRandom.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        } else {
            // Set initial position to first waypoint
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.position = currentWaypoint.position;

            //Set the next waypoint target
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomSpawn) {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThershold) {

                currentWaypoint = waypointsRandom.GetNextWaypoint(currentWaypoint);
            } 
        } else {
             transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThershold) {

                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                //transform.LookAt(currentWaypoint);
            }
        }
        RotateTowardsWaypoint();
    }

    //Slow rotate
     void RotateTowardsWaypoint() {

        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        roationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, roationGoal * Quaternion.Euler(startrotationAnglex, startrotationAngley, startrotationAnglez), rotateSpeed * Time.deltaTime);
    }
}

