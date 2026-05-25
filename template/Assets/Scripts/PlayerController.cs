using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.8f;


    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    private Vector2 cameraInput;


    double tagcooldown;
    bool sprintingnow;
    public float sprintlength;
    public float sprintleft;


    float xRotation;//////////
    public Camera cam;/////////

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
            //jumpaction();
            //Debug.Log("attempting jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void SprintTimeout(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("sprint ran out");
        }
        if (context.canceled)
        {
            Debug.Log("sprint reset");
        }
        
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = 10f;
            sprintingnow = true;
        }
        if (context.canceled)
        {
            speed = 5f;
            sprintingnow = false;
        }
        
    }
    public void Crouch(InputAction.CallbackContext context)
    {

    }
    public void StartRound(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameObject RoundController;
            GameStateController gameStateController;
            RoundController = GameObject.FindGameObjectWithTag("GameController");
            gameStateController = RoundController.GetComponent<GameStateController>();
            gameStateController.StartRound();
        }
        
        
    }
    public void Tag(InputAction.CallbackContext context)
    {
        double timesinceattempted;
        if(context.performed)
        {
            timesinceattempted = context.time;
            Debug.Log(timesinceattempted);
        }
    }
    public void CameraControl(InputAction.CallbackContext context)
    {
        cameraInput = context.ReadValue<Vector2>();
    }


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        sprintleft = sprintlength;
    }


    // Update is called once per frame
    void Update()
    {
        
        //camera stuff
        float camX = cameraInput.x;
        float camY = cameraInput.y;
        xRotation -= camY;
        xRotation = Mathf.Clamp(xRotation, -88f,88f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * camX);
        //moving the character
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        sprintAntiSpam();
        
    }
    void sprintAntiSpam()
    {
        if (sprintingnow == true)
        {
            if(sprintleft > 0)
            {
                sprintleft -= Time.deltaTime;
            }
            if (sprintleft < 0)
            {
                Debug.Log("out of spritn");
                speed = 2f;
            }
        }
        if (sprintingnow == false)
        {
            if (sprintleft <= sprintlength)
            {
                sprintleft += Time.deltaTime;
            }
        }
    }

    public void SetRole()
    {

    }
    public void jumpaction()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
