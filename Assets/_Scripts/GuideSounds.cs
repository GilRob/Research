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

    public int randomNum = 0;

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

        randomNum = Random.Range(1, 4);
        Debug.Log(randomNum);

        if (randomNum == 1)
        {
            GameObject.Find("Accuracy Triggers Path 2").SetActive(false);
            GameObject.Find("Accuracy Triggers Path 3").SetActive(false);
        }
        else if (randomNum == 1)
        {
            GameObject.Find("Accuracy Triggers Path 1").SetActive(false);
            GameObject.Find("Accuracy Triggers Path 3").SetActive(false);
        }
        else
        {
            GameObject.Find("Accuracy Triggers Path 1").SetActive(false);
            GameObject.Find("Accuracy Triggers Path 2").SetActive(false);
        }

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

        //Path to chair if randomNum is 1 or 2
        if (randomNum != 3)
        {
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
        //Path to chair if randomNum is 3
        else
        {
            //Janky things to make audio clip play without dings
            if (checkpoint == 11 && !gameObject.GetComponent<AudioSource>().isPlaying)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guide")
        {
            Debug.Log("Triggered");

            //Path to chair if randomNum is 1
            if (randomNum == 1)
            {
                if (checkpoint == 1)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -15.5f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 2)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -6f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 3)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 4)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-1.5f, 3.58f, 0f);
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(3f, 8f, 3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 5)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 6)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(5.97f, 3.58f, 8.97f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 7)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
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
            //Path to chair if randomNum is 2
            else if (randomNum == 2)
            {
                if (checkpoint == 1)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -15.5f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 2)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -6f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 3)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 4)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(-4f, 3.58f, 0f);
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(3f, 8f, 3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 5)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(1.63f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 6)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position
                    other.gameObject.transform.position = new Vector3(1.63f, 3.58f, -5.45f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 7)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
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
                    other.gameObject.transform.position = new Vector3(1.63f, 3.58f, 0f);

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
            //Path to chair if randomNum is 3
            else if (randomNum == 3)
            {
                if (checkpoint == 1)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 2
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -15.5f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 2)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 3
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, -6f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 3)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 4
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 4)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 5
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 8f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 5)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 6
                    other.gameObject.transform.position = new Vector3(-8.5f, 3.58f, 15.3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 6)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 7
                    other.gameObject.transform.position = new Vector3(0f, 3.58f, 15.3f);
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(3f, 8f, 3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 7)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 8
                    other.gameObject.transform.position = new Vector3(5.9f, 3.58f, 15.3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 8)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 8
                    other.gameObject.transform.position = new Vector3(9.4f, 3.58f, 15.3f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 9)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
                    userMetrics.guideTimer = 0.0f;

                    //Change collider position to guide 8
                    other.gameObject.transform.position = new Vector3(9.4f, 3.58f, 9f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 10)
                {
                    //Add to guide List
                    userMetrics.guideSplits.Add(userMetrics.guideTimer);
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
                    other.gameObject.transform.position = new Vector3(9.4f, 3.58f, 4.4f);

                    checkpoint++;
                }
                else if (checkpoint == 12)
                {
                    //Change collider position
                    other.gameObject.transform.position = new Vector3(10f, 3.58f, 0f);

                    //Spotlight movement
                    spotLight.transform.position = new Vector3(other.transform.position.x, 8.13f, other.transform.position.z);
                    checkpoint++;
                }
                else if (checkpoint == 13)
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
