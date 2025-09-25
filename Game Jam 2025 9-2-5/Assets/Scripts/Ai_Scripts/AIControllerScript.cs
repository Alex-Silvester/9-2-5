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
    public Animator anim;

    //waypoints
    public Transform[] waypoints;
    public Transform KeyWaypoint;
    int waypointIndex;
    Vector3 target;

    //timers
    public float max_time_waiting = 5.0f;
    public float desk_time_waiting = 20f;

    [SerializeField]
    float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 0)
        {
            anim.SetBool("Moving", true);
        }
        else if (time > 0)
        {
            anim.SetBool("Moving", false);
        }
        // Calculate time.
        if (Vector3.Distance(agent.transform.position, target) <= 2)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0.0f;
        }

        // Time is up.
        if (time >= max_time_waiting)
        {
            //Debug.Log($"Stopped waiting {time}");

            //IterateWaypointIndex();
            UpdateDestination();

            // Reset time.
            time = 0.0f;
        }

        if(Vector3.Distance(agent.transform.position, KeyWaypoint.position) <= 2 && target == KeyWaypoint.position)
        {
            max_time_waiting = desk_time_waiting;
        }
        else
        {
            max_time_waiting = 5.0f;
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
