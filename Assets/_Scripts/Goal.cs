using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Variables
    private GameObject obj;

    private bool goalReached;

    // Start is called before the first frame update
    void Start()
    {
        goalReached = false;
        obj = GameObject.FindGameObjectWithTag("Pickup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        goalReached = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        goalReached = false;
    }
}
