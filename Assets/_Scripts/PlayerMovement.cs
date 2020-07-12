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

    private bool vrEnabled;


    private void Start()
    {
        if (XRDevice.isPresent)
        {
            vrEnabled = true;
            GameObject.Find("handL").SetActive(true);
            GameObject.Find("handR").SetActive(true);
            GameObject.Find("Cameras").SetActive(true);
            GameObject.Find("Camera").SetActive(false);
            /*GameObject.Find("Player").SetActive(false);
            GameObject.Find("WebXRCameraSet").SetActive(true);*/
        }
        else
        {
            vrEnabled = false;
            GameObject.Find("handL").SetActive(false);
            GameObject.Find("handR").SetActive(false);
            GameObject.Find("Cameras").SetActive(false);
            GameObject.Find("Camera").SetActive(true);
            /*GameObject.Find("Player").SetActive(true);
            GameObject.Find("WebXRCameraSet").SetActive(false);*/
        }

        Debug.Log(vrEnabled);
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
        Vector3 move = transform.right * x + transform.forward * z;

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
