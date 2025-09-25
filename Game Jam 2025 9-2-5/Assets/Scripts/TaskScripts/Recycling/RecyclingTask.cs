using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RecyclingTask", menuName = "Scriptable Objects/RecyclingTask")]
public class RecyclingTask : Task
{
    int max_presses = 15;
    int num_of_presses_needed = 0;
    int num_of_presses = 0;

    public override void initTask()
    {
        base.initTask();

        num_of_presses = 0;
        num_of_presses_needed = (int)Math.Floor(UnityEngine.Random.value * max_presses) + 1;
    }
    public override void run()
    {
        if(num_of_presses == num_of_presses_needed)
        {
            Debug.Log($"Num: {num_of_presses} Needed: {num_of_presses_needed}");
            Debug.Log("Complete");
            complete = true;
        }
    }

    public void press()
    {
        num_of_presses++;
    }
}
