using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class AIControllerScript : MonoBehaviour
{

    NavMeshAgent agent;

    //waypoints
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    public float speed;

    //timers
    public float max_time_waiting;
    public float time;
    uint time_mul;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {

        Random rnd = new Random();
        int numbercheck = waypoints.Length;




        // Calculate time.
        time = (Time.time - (max_time_waiting * time_mul));
        // Time is up.
        if (time >= max_time_waiting)
        {
            // Do whatever:
            //print("help");
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
            waypointIndex = rnd.Next(0, numbercheck);
            //print(waypointIndex);
            //IterateWaypointIndex();
            UpdateDestination();

            // Reset time.
            time = 0.0f;
            time_mul++;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
