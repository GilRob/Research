using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Variables
    public float mouseSensitivity = 100.0f;

    public Transform playerBody;

    float xRotation = 0.0f;

    private bool mouseHidden;

    public PlayerMovement playerMovement;

    //VR stuff
    public Transform vrCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor to the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseHidden = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Variables to simplify code
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        if (!playerMovement.vrEnabled)
        {
            //Decrease x rotation by mouse y every frame
            xRotation -= mouseY;
            //Clamp rotation
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            //Camera movement code
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

        //Make cursor unlocked and visible
        if (Input.GetKeyUp(KeyCode.KeypadEnter) && mouseHidden == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseHidden = false;
        }
        //Make cursor locked and invisible again
        else if (Input.GetKeyUp(KeyCode.KeypadEnter) && mouseHidden == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseHidden = true;
        }

    }
}
