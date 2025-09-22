using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;

public class TaskManagerScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> task_prompts;

    bool task_selected = false;

    int task_idx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if there is no task selected, select a task
        if (!task_selected)
        {
            selectTask();
        }
        else if (task_prompts[task_idx].GetComponent<InteractPromptUI>().taskComplete())
        {
            task_prompts[task_idx].GetComponent<InteractPromptUI>().resetTask();
            task_selected = false;
        }
    }

    void selectTask()
    {
        //select a random task that isn't the last task

        int prev_idx = task_idx;
        task_idx = (int)Math.Floor(UnityEngine.Random.value * task_prompts.Capacity);

        if(task_idx == prev_idx && task_prompts.Capacity > 1)
        {
            task_idx = (task_idx + 1)%task_prompts.Capacity;
        }

        //tell the task that it has been selected
        task_prompts[task_idx].GetComponent<InteractPromptUI>().select();

        //stop selecting new tasks
        task_selected = true;

        Debug.Log($"Task: {task_idx}");
    }

    public bool taskInProgress()
    {
        return task_prompts[task_idx].GetComponent<InteractPromptUI>().inProgress();
    }

    public void pauseTask()
    {
        task_prompts[task_idx].GetComponent<InteractPromptUI>().pauseTask();
    }

    public void returnTask()
    {
        task_prompts[task_idx].GetComponent<InteractPromptUI>().returnTask();
    }
}
