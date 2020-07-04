using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Variables
    private GameObject obj;
    public AudioSource source;
    public GameObject player;

    public AudioClip[] clipList;

    public bool goalReached;

    public UserMetricsCapture userMetrics;

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
        //Play audio clip telling user to proceed to the door on their left
        player.GetComponent<AudioSource>().clip = clipList[2];
        player.GetComponent<AudioSource>().Play();
        
        Destroy(collision.gameObject);
        userMetrics.taskSplits[0] = userMetrics.taskTimer;
        userMetrics.taskTimer = 0.0f;
        //goalReached = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        goalReached = false;
    }
}
