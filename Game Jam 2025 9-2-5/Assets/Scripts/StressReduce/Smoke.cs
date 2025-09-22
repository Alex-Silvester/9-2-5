using System.Diagnostics;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public TimerStressScript StressScript;
    public float ReductionAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SmokeAction()
    {
        StressScript.stress -= ReductionAmount;
        print(StressScript.stress_meter);
       
    }
}
