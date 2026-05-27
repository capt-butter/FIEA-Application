//using Unity.ProjectAuditor.Editor;
using UnityEngine;

public class PowerupPads : MonoBehaviour
{
    public string[] options = {"autojumper", "jumpbooster", "moon grav", "slowspeed", "sprint reset", "sprint plus" };
    public int choice;
    public Material[] powerupvisual;

    Material itemmat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (choice < 0 || choice > options.Length)
        {
            //sets it to 0 to prevent array errors and then disables the object
            choice  = 0; 
            gameObject.SetActive(false);
        }
        itemmat = GetComponent<Material>();
        itemmat = powerupvisual[choice];
        gameObject.GetComponent<MeshRenderer>().material = itemmat;
        if (choice == 0)//autojumper
        {
            
        }
        if (choice == 1)//super jump
        { 
            
        }
        if (choice == 2)//moon gravity
        {

        }
        if (choice == 3)//slowzone
        {

        }
        if (choice == 4)//reset sprint
        {

        }
        if (choice == 5)//sets sprint super high
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController script = other.GetComponentInParent<PlayerController>();
        if (script != null) 
        {
            Debug.Log("player captured");
        }
        if (choice == 0)//autojumper
        {
            script.jumpHeight = 4f;
            script.jumpaction();
        }
        if (choice == 1)//super jump
        {
            script.jumpHeight = 5f;
        }
        if (choice == 2)//moon gravity
        {
            //script.gravity = -3f;
        }
        if (choice == 3)//slowzone
        {
            script.speed = 2f;
        }
        if (choice == 4)//reset sprint
        {
            script.sprintlength = 5f;
        }
        if (choice == 5)//sets sprint super high
        {
            script.sprintleft = 10f;
        }

        //expand tag box
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerController script = other.GetComponentInParent<PlayerController>();
        if (choice == 0)//autojumper
        {

        }
        if (choice == 1)//super jump
        {
            script.jumpHeight = 5f;
        }
        if (choice == 2)//moon gravity
        {
            //script.gravity = -3f;
        }
        if (choice == 3)//slowzone
        {
            script.speed = 2f;
        }
        if (choice == 4)//reset sprint
        {
            script.sprintleft = 5f;
        }
        if (choice == 5)//sets sprint super high
        {
            script.sprintleft = 10f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController script = other.GetComponentInParent<PlayerController>();
        if (choice == 0)//autojumper
        {
            script.jumpHeight = 2f;
        }
        if (choice == 1)//super jump
        {
            script.jumpHeight = 2f;
        }
        if (choice == 2)//moon gravity
        {
            //script.gravity = -9.8f;
        }
        if (choice == 3)//slowzone
        {
            script.speed = 5f;
        }
        if (choice == 4)//reset sprint
        {
            script.sprintleft = 5f;
        }
        if (choice == 5)//sets sprint super high
        {
            script.sprintleft = 10f;
        }
    }
    private void Update()
    {
        //cooldown code

    }
}
