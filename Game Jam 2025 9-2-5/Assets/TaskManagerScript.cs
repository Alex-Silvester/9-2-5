using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class TaskManagerScript : MonoBehaviour
{
    public List<string> tasks;

    private float task_chance = 0.1f;
    private bool task_complete = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if there are no tasks, then don't try to assign one
        if (tasks.Capacity == 0)
        {
            return;
        }

        //select a random chance at a random time if the current task is completed
        if (UnityEngine.Random.value <= task_chance && task_complete)
        {
            int task_idx = (int)Math.Floor(UnityEngine.Random.value * tasks.Count);
            Debug.Log($"{tasks[task_idx]}");
            task_complete = false;
        }


        /*-----temporary statement-----*/

        //in full implementation the task will signal the taskComplete function
        if(Input.GetKeyDown(KeyCode.Space))
        {
            taskCompleted();
        }

        /*-----temporary statement-----*/
    }

    public void taskCompleted()
    {
        Debug.Log("Complete");
        task_complete = true;
    }
}
