using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Start is called before the first frame update

    public float mouseSen = 550f;
    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSen * Time.deltaTime;

        yRotation+=mouseX;
        xRotation-=mouseY;

        xRotation =  Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0,yRotation,0);

        if (Input.GetKey(KeyCode.W))
        { 
            transform.rotation *= Quaternion.Euler(0, 180, 0);

        }
    }
}
