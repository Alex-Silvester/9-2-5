using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class StressReductionScript : MonoBehaviour
{

    public TimerStressScript StressScript;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.name == "PlayerCharacter")
        {
            Debug.Log(collision.gameObject.name + " has entered collsion area");
            StressScript.invert_stress = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.gameObject.name == "PlayerCharacter")
        {
            Debug.Log(collision.gameObject.name + " has left collsion area");
            StressScript.invert_stress = false;
        }
    }


}
