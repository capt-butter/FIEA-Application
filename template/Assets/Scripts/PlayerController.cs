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

    public void ProcessSprint(ref InputInteractionContext Context)
    {
        
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed = 10f;
        }
        if (context.canceled)
        {
            speed = 5f;
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
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //gameObject.transform.Rotate(0,cameraInput.x,0);
        //Debug.Log(gameObject.transform.rotation);
    }

    public void SetRole()
    {

    }
}
