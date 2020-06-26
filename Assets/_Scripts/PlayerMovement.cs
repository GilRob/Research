using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
