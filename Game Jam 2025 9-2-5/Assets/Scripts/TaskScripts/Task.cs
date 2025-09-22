using UnityEngine;


[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    protected bool complete = true;

    GameObject task_object;

    public void initTask()
    {
        complete = false;

        Debug.Log("Init");
        task_object.SetActive(true);
    }

    public void setTaskObject(GameObject task_obj)
    {
        task_object = task_obj;
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
