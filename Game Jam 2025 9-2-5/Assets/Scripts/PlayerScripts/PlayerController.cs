
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float smoothTime = 0.05f;

    [SerializeField] private float gravity = -9.81f;
    private float gravity_multiplier = 3.0f;
    [SerializeField] private float velocity;


    private float currentVelocity;
    private CharacterController characterController;
    private Vector3 direction;
    private Vector2 move;

    public GameObject PC;
    public GameObject task_manager;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        direction = new Vector3(move.x, 0, move.y);
    }


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       Gravity();
       Rotation();

       if (Input.GetKeyDown(KeyCode.F))
       {
           stopMovingPlayer();
       }
       
       if(!task_manager.GetComponent<TaskManagerScript>().taskInProgress())
       {
           movePlayer();
       }
        
    }

    public void Gravity()
    {
        if (characterController.isGrounded && velocity < 0.0f)
        {
            velocity = -0.1f;
        }

        else
        {
            velocity += gravity * gravity_multiplier * Time.deltaTime;
        }

        direction.y = velocity;

    }

    public void Rotation()
    {
        if (move.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    public void movePlayer()
    {
        characterController.Move(direction * speed * Time.deltaTime);             
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
