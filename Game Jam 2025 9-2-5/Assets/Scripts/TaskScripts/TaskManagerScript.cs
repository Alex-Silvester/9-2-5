using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class TaskManagerScript : MonoBehaviour
{
    public List<GameObject> tasks;

    private float task_chance = 0.1f;
    private bool task_complete = true;

    private int current_task_idx;

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
            current_task_idx = (int)Math.Floor(UnityEngine.Random.value * tasks.Count);
            Debug.Log($"{tasks[current_task_idx]}");
            task_complete = false;
        }

        if (tasks[current_task_idx].GetComponent<Task>().isComplete())
        {
            task_complete = true;
            tasks[current_task_idx].GetComponent<Task>().reset();
        }
    }
}
