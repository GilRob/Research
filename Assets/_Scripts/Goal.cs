using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Variables
    private GameObject obj;
    public AudioSource source;

    public AudioClip[] clipList;

    public bool goalReached;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        goalReached = false;
        obj = GameObject.FindGameObjectWithTag("Pickup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.clip = clipList[1];
        source.loop = false;
        source.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
        goalReached = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        goalReached = false;
    }
}
