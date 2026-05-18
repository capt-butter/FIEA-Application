using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController playercontroller;
    public Camera POV;
    public float speedmuti = 10f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform groundcheck;
    public float grounddistance = 0.1f;
    public LayerMask groundmask;
    bool isonground;

    


    // Update is called once per frame
    void Update()
    {
        
        

        isonground = Physics.CheckSphere(groundcheck.position, grounddistance,groundmask);

        if(isonground && velocity.y <0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = POV.transform.right * x + POV.transform.forward * z;

        playercontroller.Move(movement*speedmuti*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        playercontroller.Move(velocity * Time.deltaTime);
    }
}
