using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
        Debug.Log("got new movement");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        Debug.Log(move);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
