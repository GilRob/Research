using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSounds : MonoBehaviour
{
    public AudioClip[] clipList;
    private GameObject guide;

    private Goal goal;

    private GameObject door;

    //Use this to tell the user metrics they have completed the program
    public bool completed;
    //Use this to tell user metrics they have completed the guides to the seat
    public bool guidesCompleted;
    public bool guideSection;
    
    public UserMetricsCapture userMetrics;

    //Used to keep track of where they are at in the guides
    private int checkpoint = 1;

    public GameObject spotLight;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Goal>();
        guide = GameObject.Find("Source1");
        door = GameObject.Find("Door");
        //Disable collider initially. Have it enabled once they register
        guide.GetComponent<BoxCollider>().enabled = false;
        guide.GetComponent<AudioSource>().enabled = false;

        completed = false;
        guidesCompleted = false;
        guideSection = false;
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
                Destroy(door);
                guideSection = true;

                //Spotlight movement
                spotLight.transform.position = new Vector3(guide.transform.position.x, 8.13f, guide.transform.position.z);
            }

        }

        //Janky things to make audio clip play without dings
        if (checkpoint == 8 && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            guide.GetComponent<AudioSource>().clip = clipList[0];
            guide.GetComponent<AudioSource>().loop = true;
            guide.GetComponent<AudioSource>().Play();
            Debug.Log("Podium Time");

            //Spotlight movement
            spotLight.transform.position = new Vector3(guide.transform.position.x, 8.13f, guide.transform.position.z);
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
                //Add to guide array
                userMetrics.guideSplits[0] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -18f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 2)
            {
                //Add to guide array
                userMetrics.guideSplits[1] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -11f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 3)
            {
                //Add to guide array
                userMetrics.guideSplits[2] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 0f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 4)
            {
                //Add to guide array
                userMetrics.guideSplits[3] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(-1.5f, 3.58f, 0f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 5)
            {
                //Add to guide array
                userMetrics.guideSplits[4] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 0f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 6)
            {
                //Add to guide array
                userMetrics.guideSplits[5] = userMetrics.guideTimer;
                userMetrics.guideTimer = 0.0f;

                //Change collider position
                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 8.97f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            else if (checkpoint == 7)
            {
                //Add to guide array
                userMetrics.guideSplits[6] = userMetrics.guideTimer;
                guidesCompleted = true;
                //userMetrics.guideTimer = 0.0f;

                //Add to task array
                userMetrics.taskSplits[1] = userMetrics.taskTimer;
                userMetrics.taskTimer = 0.0f;

                other.gameObject.GetComponent<AudioSource>().clip = clipList[1];
                other.gameObject.GetComponent<AudioSource>().loop = false;
                other.gameObject.GetComponent<AudioSource>().Play();

                //Play the find podium voice clip
                gameObject.GetComponent<AudioSource>().clip = clipList[2];
                gameObject.GetComponent<AudioSource>().Play();

                //Change collider position
                other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 0f);

                checkpoint++;
            }
            else if (checkpoint == 9)
            {
                //Change collider position
                other.gameObject.transform.position = new Vector3(10f, 3.58f, 0f);

                //Spotlight movement
                spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                checkpoint++;
            }
            /*else if (checkpoint == 9)
            {
                checkpoint++;
            }*/
            else if (checkpoint == 10)
            {
                //Add to task array
                userMetrics.taskSplits[2] = userMetrics.taskTimer;

                completed = true;

                other.gameObject.GetComponent<AudioSource>().clip = clipList[1];
                other.gameObject.GetComponent<AudioSource>().loop = false;
                other.gameObject.GetComponent<AudioSource>().Play();

                //Play the ending voice clip
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
