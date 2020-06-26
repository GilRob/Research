using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Variables
    private GameObject obj;
    private GameObject door;
    public AudioSource source;

    public AudioClip[] clipList;

    public bool goalReached;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        goalReached = false;
        obj = GameObject.FindGameObjectWithTag("Pickup");
        door = GameObject.Find("Door");
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
        //Play audio clip telling user to proceed to the door on their left
        Destroy(door, 2f);
        Destroy(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        goalReached = false;
    }
}
