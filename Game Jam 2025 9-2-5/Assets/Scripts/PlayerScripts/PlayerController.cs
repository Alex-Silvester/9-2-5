
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int destress_cig;
    public float smoothTime = 0.05f;
    public Animator anim;
    public bool moving = false;

    [SerializeField] private float gravity = -9.81f;
    private float gravity_multiplier = 3.0f;
    [SerializeField] private float velocity;


    public float currentVelocity;
    private CharacterController characterController;
    private Vector3 direction;
    private Vector2 move;
    public Vector3 movingvelo; 

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
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(moving);
       Gravity();
       Rotation();
       if (Input.GetKeyDown(KeyCode.F))
       {
           stopMovingPlayer();
       }
       
       if(!task_manager.GetComponent<TaskManagerScript>().taskInProgress())
       {
           movePlayer();
            Animation();  
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


    public void Animation()
    {
        if(Input.GetKey(KeyCode.W))
        {
            moving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moving = true;
        }
        else
        {
            moving = false;    
        }

        if (moving == true)
        {
            anim.SetBool("Moving", true);
        }
        else if (moving == false)
        {
            anim.SetBool("Moving", false);
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
