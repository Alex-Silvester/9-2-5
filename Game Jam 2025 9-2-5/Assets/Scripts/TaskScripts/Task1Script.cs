using Unity.VisualScripting;
using UnityEngine;

public class Task1Script : MonoBehaviour
{
    Task task_info;

    [SerializeField]
    GameObject task_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        task_info.setPosition(task_position);
    }

    // Update is called once per frame
    void Update()
    {
        if(task_info.isActive())
        {
            runTask();
        }
    }

    private void runTask()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            task_info.completed();
        }
    }
}
