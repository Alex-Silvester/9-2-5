using UnityEngine;

[CreateAssetMenu(fileName = "PCTask", menuName = "Scriptable Objects/PCTask")]
public class PCTask : Task
{
    public override void run()
    {
 /*       if(Input.GetKey(KeyCode.Space))
        {
            complete = true;
            Debug.Log("Task Complete");
        }*/
    }

    public void sendEmail()
    {
        complete=true;
    }
}
