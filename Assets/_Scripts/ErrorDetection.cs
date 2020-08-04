using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorDetection : MonoBehaviour
{
    private bool soundPlaying = false;

    public UserMetricsCapture userMetrics;

    private GameObject wallAudio;

    // Start is called before the first frame update
    void Start()
    {
        wallAudio = GameObject.Find("Wall Audio");
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
                //Vector3 soundPos;
                //other.gameObject.GetComponentInChildren<Transform>().transform.localPosition = new Vector3(wallAudio.transform.position.x, wallAudio.transform.position.y, this.gameObject.transform.position.z);
                wallAudio.transform.position = new Vector3(this.gameObject.transform.position.x, other.gameObject.transform.position.y, this.gameObject.transform.position.z);
                Debug.Log(wallAudio.transform.position);
                //soundPos = this.gameObject.transform.position - wallAudio.transform.position;

                //wallAudio.transform.position = soundPos;
                //Debug.Log(soundPos);
                wallAudio.GetComponent<AudioSource>().Play();
                //other.gameObject.GetComponentInChildren<AudioSource>().Play();
                soundPlaying = true;
                Debug.Log("COLLIDE");
            }
            if (wallAudio.GetComponent<AudioSource>().isPlaying == false)
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
            wallAudio.GetComponent<AudioSource>().Stop();
            //other.gameObject.GetComponentInChildren<AudioSource>().Stop();
            userMetrics.numWallCollisions++;
        }
    }
}
