using Unity.Mathematics;
using UnityEngine;

public class playermousing : MonoBehaviour
{
    public float mousesens = 10f;
    public Transform playerbody;
    float xrotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mousesens * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesens * Time.deltaTime;
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex);
    }
}
