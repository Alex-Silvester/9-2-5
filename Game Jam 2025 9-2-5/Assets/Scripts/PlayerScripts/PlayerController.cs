using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    public GameObject PC;
    public GameObject task_manager;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            stopMovingPlayer();
        }

        if(!task_manager.GetComponent<TaskManagerScript>().taskInProgress())
        {
            movePlayer();
        }
        
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);
        }       
    }

    public void stopMovingPlayer()
    {
        speed = 0f;
    }

    public void resumeMovingPlayer()
    {
        speed = 5f;
    }

}
