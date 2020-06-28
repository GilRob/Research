using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSounds : MonoBehaviour
{
    public AudioClip[] clipList;
    private GameObject guide;

    private Goal goal;

    //Used to keep track of where they are at in the guides
    private int checkpoint = 1;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Goal>();
        guide = GameObject.Find("Source1");
        //Disable collider initially. Have it enabled once they register
        guide.GetComponent<BoxCollider>().enabled = false;
        guide.GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.goalReached)
        {
            //Janky things to make audio clip play without dings
            if (checkpoint == 1 && !gameObject.GetComponent<AudioSource>().isPlaying)
            {
                guide.GetComponent<BoxCollider>().enabled = true;
                guide.GetComponent<AudioSource>().enabled = true;
            }

        }

        //Janky things to make audio clip play without dings
        if (checkpoint == 8 && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            guide.GetComponent<AudioSource>().clip = clipList[0];
            guide.GetComponent<AudioSource>().loop = true;
            guide.GetComponent<AudioSource>().Play();
            Debug.Log("Podium Time");
            checkpoint++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guide")
        {
            Debug.Log("Triggered");

            if (checkpoint == 1)
            {
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -18f);
                checkpoint++;
            }
            else if (checkpoint == 2)
            {
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -11f);
                checkpoint++;
            }
            else if (checkpoint == 3)
            {
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 0f);
                checkpoint++;
            }
            else if (checkpoint == 4)
            {
                other.gameObject.transform.position = new Vector3(-1.5f, 3.58f, 0f);
                checkpoint++;
            }
            else if (checkpoint == 5)
            {
                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 0f);
                checkpoint++;
            }
            else if (checkpoint == 6)
            {
                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 8.97f);
                checkpoint++;
            }
            else if (checkpoint == 7)
            {
                other.gameObject.GetComponent<AudioSource>().clip = clipList[1];
                other.gameObject.GetComponent<AudioSource>().loop = false;
                other.gameObject.GetComponent<AudioSource>().Play();

                gameObject.GetComponent<AudioSource>().clip = clipList[2];
                gameObject.GetComponent<AudioSource>().Play();

                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 0f);
                checkpoint++;
            }
            else if (checkpoint == 9)
            {
                other.gameObject.transform.position = new Vector3(10f, 3.58f, 0f);
                checkpoint++;
            }
            /*else if (checkpoint == 9)
            {
                checkpoint++;
            }*/
            else if (checkpoint == 10)
            {
                other.gameObject.GetComponent<AudioSource>().clip = clipList[1];
                other.gameObject.GetComponent<AudioSource>().loop = false;
                other.gameObject.GetComponent<AudioSource>().Play();

                gameObject.GetComponent<AudioSource>().clip = clipList[3];
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");

            if (checkpoint == 1)
            {
                gameObject.transform.position = new Vector3(-8.5f, 3.58f, -18f);
                checkpoint++;
            }
            else if (checkpoint == 2)
            {
                gameObject.transform.position = new Vector3(-8.5f, 3.58f, -11f);
                checkpoint++;
            }
        }
    }*/
}
