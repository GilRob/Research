using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public CharacterController controller;

    public float speed = 12.0f;
    public float gravity = -9.81f;
    private float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    public PluginTester tester;
    private int jumpCounter = 0;

    private Vector3 move;

    //public static bool vrEnabled;

    private StartingScript starting;

    bool isRotating = false;

    //VR Camera
    public Transform vrCameraTransform;

    private void Start()
    {
        starting = GameObject.Find("Starter").GetComponent<StartingScript>();

        if (starting.vrEnabled && XRDevice.isPresent)
        {
            starting.vrEnabled = true;
            GameObject.Find("OVRCameraRig").SetActive(true);
            GameObject.Find("LocalAvatar").SetActive(true);
            //GameObject.Find("Cameras").SetActive(true);
            GameObject.Find("Camera").SetActive(false);
            /*GameObject.Find("Player").SetActive(false);
            GameObject.Find("WebXRCameraSet").SetActive(true);*/
        }
        else
        {
            starting.vrEnabled = false;
            GameObject.Find("OVRCameraRig").SetActive(false);
            GameObject.Find("LocalAvatar").SetActive(false);
            //GameObject.Find("Cameras").SetActive(false);
            GameObject.Find("Camera").SetActive(true);
            /*GameObject.Find("Player").SetActive(true);
            GameObject.Find("WebXRCameraSet").SetActive(false);*/
        }

        Debug.Log(starting.vrEnabled);
    }
    // Update is called once per frame
    void Update()
    {
        //Creates an invisible sphere based on groundcheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //Force player on ground, just to be safe
            velocity.y = -2.0f;
        }

        //Input variables to simplify future code
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //Movement has to be local
        if (!starting.vrEnabled)
        {
            move = transform.right * x + transform.forward * z;
        }

        //For VR movement
        if (starting.vrEnabled)
        {
            //Movement has to be local
            move = vrCameraTransform.right * x + vrCameraTransform.forward * z;
        }

        float rotation = Input.GetAxis("HorizontalRight");
        
        if (rotation > 0 && !isRotating)
        {
            transform.Rotate(0f, 45f, 0f);
            isRotating = true;
        }
        else if (rotation == 0 && isRotating)
            isRotating = false;
        else if (rotation < 0 && !isRotating)
        {
            transform.Rotate(0f, -45f, 0f);
            isRotating = true;
        }


        controller.Move(move * speed * Time.deltaTime);

        //Jump, probably not needed for this project, but it is here
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumpCounter++;
            tester.numJumps = jumpCounter.ToString();
            //tester.numJumps++;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
