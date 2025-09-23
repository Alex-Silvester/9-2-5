using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CoffeeMachine", menuName = "Scriptable Objects/CoffeeMachine")]
public class CoffeeMachine : Task
{
    float time = 0f;
    bool coffee_made = false;
    public override void run()
    {

        if (Input.GetKeyDown(KeyCode.E) && coffee_made == true)
        {
            Debug.Log("Coffee Drank");
            coffee_made = false;
            complete = true;
            time = 0f;
            return;
        }

        Debug.Log("Making Coffee");
        optional_interactable.GetComponent<PlayerController>().stopMovingPlayer();

        time += Time.deltaTime;
        Debug.Log(time);

        if (time >= 3)
        {
            time = 3f;
            Debug.Log("Coffee Made");
            optional_interactable.GetComponent<PlayerController>().resumeMovingPlayer();
            coffee_made = true;
        }
    }
}
    

