using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorDetection : MonoBehaviour
{
    private bool soundPlaying = false;

    public UserMetricsCapture userMetrics;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            if (!soundPlaying)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
                soundPlaying = true;
                //Debug.Log("COLLIDE");
            }
            if (other.gameObject.GetComponent<AudioSource>().isPlaying == false)
                soundPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Accuracy")
        {
            userMetrics.inaccuracies.Add(other.gameObject.name + ":, " + System.DateTime.Now.ToLongTimeString() + "\n");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            other.gameObject.GetComponent<AudioSource>().Stop();
            userMetrics.numWallCollisions++;
        }
    }
}
