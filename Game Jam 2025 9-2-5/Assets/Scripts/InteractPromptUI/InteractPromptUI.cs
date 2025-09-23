using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class InteractPromptUI : MonoBehaviour
{
    bool PlayerInTrigger = false;
    public KeyCode InteractKey;
    public GameObject InteractPrompt_UI;
    public GameObject TargetUI;
    public Task task;

    [SerializeField]
    GameObject optional_interactable;

    public bool selected = false;
    public bool always_active = false;

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

        if(!optional_interactable.IsUnityNull())
        {
            task.setInteractable(optional_interactable);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if this task is not selected, then don't run it
        if(!selected && !always_active)
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

            if (!TargetUI.IsUnityNull())
            {
                TargetUI.SetActive(true);
            }

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

        Debug.Log("Task Complete!");

        if (!TargetUI.IsUnityNull())
        {
            TargetUI.SetActive(false);
        }

        task_in_progress = false;
        selected = false;
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
