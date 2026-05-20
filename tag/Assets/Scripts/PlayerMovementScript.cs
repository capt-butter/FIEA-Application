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

    public float sprintmulti;
    bool cansprint;
    public float maxsprinttimer;
    public float sprintremaining;

    

    void Start()
    {
        sprintremaining = maxsprinttimer;
    }
    // Update is called once per frame
    void Update()
    {

        Sprintingcode();
        CrouchingCode();

        isonground = Physics.CheckSphere(groundcheck.position, grounddistance,groundmask);

        if(isonground && velocity.y <0)
        {
            //velocity.y = -10f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = POV.transform.right * x + POV.transform.forward * z;

        playercontroller.Move(movement*speedmuti*Time.deltaTime);
        velocity.y = gravity;
        //velocity.y += gravity * Time.deltaTime;
        playercontroller.Move(velocity * Time.deltaTime);
    }

    void Sprintingcode()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (sprintremaining >= 0)
            {
                cansprint = true;
            }
        }
        if (cansprint == true)
        {
            sprintmulti = 2;
            sprintremaining -= Time.deltaTime;
            if (sprintremaining < 0)
            {
                cansprint = false;
                sprintmulti = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cansprint = false;
            sprintmulti = 1;
        }
        if (cansprint == false && sprintremaining <= 5)
        {
            sprintremaining += Time.deltaTime;
        }
    }

    void CrouchingCode()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

            sprintmulti = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            sprintmulti = 0.5f;
        }
    }
}
