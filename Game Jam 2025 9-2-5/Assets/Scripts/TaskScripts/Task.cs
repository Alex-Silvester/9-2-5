using UnityEngine;


[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    protected bool complete = false;

    public void initTask()
    {
        complete = false;

        Debug.Log("Init");
    }
    public bool isComplete()
    {
        return complete;
    }

    //Essentially the update loop
    //Can be overrided to create new tasks in child classes
    public virtual void run()
    {

    }

    public void reset()
    {
        complete = false;
    }
}
