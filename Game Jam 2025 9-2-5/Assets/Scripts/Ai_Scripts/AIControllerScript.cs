using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    public float max_time_waiting = 5.0f;
    private float time = 0;
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
        //Debug.Log(target);
        //Debug.Log(agent.transform.position);

        // Calculate time.
        if (Vector3.Distance(agent.transform.position, target) <= 2)
        {
            Debug.Log("Close Enough");
            time = (Time.time - (max_time_waiting * time_mul));
        }
        else
        {
            time = 0.0f;
        }
        // Time is up.
        if (time >= max_time_waiting)
        {
            // Do whatever:
            //print("help");
            //transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            //IterateWaypointIndex();
            UpdateDestination();

            // Reset time.
            time = 0.0f;
            time_mul++;
        }
    }

    void UpdateDestination()
    {
        Random rnd = new Random();
        int numbercheck = waypoints.Length;
        waypointIndex = rnd.Next(0, numbercheck);

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
