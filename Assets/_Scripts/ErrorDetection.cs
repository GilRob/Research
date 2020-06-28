using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorDetection : MonoBehaviour
{
    private bool soundPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Wall")
        {

            if (!soundPlaying)
            {
                hit.gameObject.GetComponent<AudioSource>().Play();
                soundPlaying = true;
            }

            if (hit.gameObject.GetComponent<AudioSource>().isPlaying == false)
                soundPlaying = false;
        }
        else if (hit.gameObject.tag != "Wall")
        {
            GameObject.FindGameObjectWithTag("Wall").GetComponent<AudioSource>().Stop();
        }
    }*/
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
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
            other.gameObject.GetComponent<AudioSource>().Stop();
    }
    /*private void OnTriggerStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("COLLIDE");
        }  
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            collision.gameObject.GetComponent<AudioSource>().Stop();
    }*/
}
