using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CoffeeMachine", menuName = "Scriptable Objects/CoffeeMachine")]
public class CoffeeMachine : Task
{
    public float time = 0f;
    public bool coffee_made = false;

    public override void initTask()
    {
        base.initTask();

        time = 0.0f;
        coffee_made = false;
    }
    public override void run()
    {

        //Debug.Log(coffee_made);

        if (Input.GetKeyDown(KeyCode.E) && coffee_made == true)
        {
            Debug.Log("Coffee Drank");
            coffee_made = false;
            complete = true;
            time = 0f;

            optional_interactable.transform.Find("TimerStressController").GetComponent<TimerStressScript>().stress -= 20;
            return;
        }

        if(coffee_made)
        {
            return;
        }

        optional_interactable.GetComponent<PlayerController>().stopMovingPlayer();

        time += Time.deltaTime;
        Debug.Log($"Making Coffee {time}");

        if (time >= 3)
        {
            time = 3f;
            Debug.Log("Coffee Made");
            optional_interactable.GetComponent<PlayerController>().resumeMovingPlayer();
            coffee_made = true;
        }
    }
}
    

