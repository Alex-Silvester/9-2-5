using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "TestTask", menuName = "Scriptable Objects/TestTask")]
public class TestTask : Task
{
    public override void run()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            complete = true;
        }
    }
}
