using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Smoking", menuName = "Scriptable Objects/Smoking")]
public class Smoking : Task
{
    public override void run()
    {
        Debug.Log("Smoking");
        if (optional_interactable.GetComponent<PlayerController>().destress_cig >= 1)
        {
            optional_interactable.GetComponent<PlayerController>().destress_cig -= 1;
            optional_interactable.transform.Find("TimerStressController").GetComponent<TimerStressScript>().stress -= 20;
            complete = true;
        }      
    }
}
