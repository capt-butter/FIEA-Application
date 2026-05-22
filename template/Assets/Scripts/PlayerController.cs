using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;


    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    private Vector2 cameraInput;


    double tagcooldown;
    bool sprintingnow;
    public float sprintlength;
    public float sprintleft;
    

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
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
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = Vector3.ClampMagnitude(move, 1f);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
            

        //controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //gameObject.transform.Rotate(0,cameraInput.x,0);
        //Debug.Log(gameObject.transform.rotation);

        Vector3 finalMove = move * speed + Vector3.up * velocity.y;
        controller.Move(finalMove * Time.deltaTime);
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
}
