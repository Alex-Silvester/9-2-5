using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class TaskManagerScript : MonoBehaviour
{
    public List<Task> tasks;

    private float task_chance = 0.1f;

    int task_idx = 0;

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

        //if the current chosen task isn't complete, then run the task
        // and don't run the next code
        if (!tasks[task_idx].isComplete())
        {
            tasks[task_idx].run();
            return;
        }

        //select a random chance at a random time if the current task is completed
        if (UnityEngine.Random.value <= task_chance)
        {
            //Get the next task
            task_idx = (int)Math.Floor(UnityEngine.Random.value * tasks.Count);
            Debug.Log($"{tasks[task_idx]}");
        }
    }
}
