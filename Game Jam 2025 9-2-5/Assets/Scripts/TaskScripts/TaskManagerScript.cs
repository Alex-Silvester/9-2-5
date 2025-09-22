using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;

public class TaskManagerScript : MonoBehaviour
{
    [SerializeField]
    List<Task> tasks;

    [SerializeField]
    List<GameObject> task_objs;

    private float task_chance = 0.1f;

    bool task_selected = false;

    int task_idx = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < tasks.Capacity; i++)
        {
            task_objs[i].SetActive(false);
            tasks[i].setTaskObject(task_objs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if there are no tasks, then don't try to assign one
        if (tasks.Capacity == 0)
        {
            return;
        }

        if(task_idx == -1)
        {
            selectTask();
            return;
        }

        //if the task is not complete and the task object is inactive
        if (!tasks[task_idx].isComplete() && !task_objs[task_idx].activeSelf)
        {
            tasks[task_idx].run();
            return;
        }

        //if the task is complete and the task object is inactive
        if (!task_objs[task_idx].activeSelf)
        {
            task_selected = false;
        }

        //select a random chance at a random time if the current task is completed
        if (UnityEngine.Random.value <= task_chance && task_selected == false)
        {
            selectTask();
        }
    }

    void selectTask()
    {
        int prev_task_idx = task_idx;

        //Get the next task
        task_idx = (int)Math.Floor(UnityEngine.Random.value * tasks.Count);

        if(task_idx == prev_task_idx)
        {
            task_idx = (task_idx + 1)%tasks.Capacity;
        }

        Debug.Log($"Task: {task_idx}");

        tasks[task_idx].initTask();

        task_selected = true;
    }
}
