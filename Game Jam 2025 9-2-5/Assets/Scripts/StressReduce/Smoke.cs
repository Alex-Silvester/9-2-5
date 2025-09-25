using System.Diagnostics;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public TimerStressScript StressScript;
    public float ReductionAmount;
    public KeyCode interact_key;

    bool in_range = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(in_range && Input.GetKeyDown(interact_key))
        {
            SmokeAction();
        }    
    }

    public void SmokeAction()
    {
        StressScript.stress -= ReductionAmount;
        print(StressScript.stress_meter);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        in_range = true;
    }

    private void OnTriggerExit(Collider other)
    {
        in_range = false;
    }
}
