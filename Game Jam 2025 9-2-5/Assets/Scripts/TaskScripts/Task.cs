using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    bool complete = false;
    bool active = false;

    GameObject task_position;

    public void setPosition(GameObject task_obj)
    {
        task_position = task_obj;
    }

    public bool isActive()
    {
        return active;
    }
    public bool isComplete()
    {
        return complete;
    }

    public void completed()
    {
        complete = true;
    }

    public void reset()
    {
        active = false;
        complete = false;
    }
}
