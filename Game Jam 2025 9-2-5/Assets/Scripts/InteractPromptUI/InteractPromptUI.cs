using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class InteractPromptUI : MonoBehaviour
{
    bool PlayerInTrigger = false;
    public KeyCode InteractKey;
    public GameObject InteractPrompt_UI;
    public GameObject TargetUI;
    public Task task;

    public bool selected = false;

    bool task_in_progress = false;

    public void select()
    {
        selected = true;

        TargetUI.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractPrompt_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if this task is not selected, then don't run it
        if(!selected)
        {
            return;
        }

        if(task_in_progress)
        {
            runTask();
            return;
        }

        if (Input.GetKeyDown(InteractKey) && PlayerInTrigger)
        {
            print("Interacted");
            InteractPrompt_UI.SetActive(false);

            TargetUI.SetActive(true);

            task_in_progress = true;
            startTask();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(!PlayerInTrigger)
        {
            InteractPrompt_UI.SetActive(true);
            PlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(PlayerInTrigger)
        {
            InteractPrompt_UI.SetActive(false);
            PlayerInTrigger = false;

            task_in_progress = false;
        }
    }

    private void startTask()
    {
        task.initTask();
    }

    private void runTask()
    { 
        //Task loop
        if(!task.isComplete())
        {
            task.run();
            return;
        }

        TargetUI.SetActive(false);
        task_in_progress = false;
        selected = false;
    }

    public void pauseTask()
    {
        task_in_progress = false;
        TargetUI.SetActive(false);
    }

    public void returnTask()
    {
        task_in_progress = true;
        TargetUI.SetActive(true);
    }

    public bool inProgress()
    {
        return task_in_progress;
    }


    public bool taskComplete()
    {
        return task.isComplete();
    }

    public void resetTask()
    {
        task.reset();
    }
}
