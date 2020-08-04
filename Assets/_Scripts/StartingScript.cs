using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartingScript : MonoBehaviour
{
    public bool vrEnabled;

    public float rayLength;
    Vector3 MousePosition;

    RaycastHit hit;
    Ray ray;
    public LayerMask layerMask;

    bool soundPlayingVR = false;
    bool soundPlayingMKB = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Variables to simplify code
        /*float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");*/

        /*MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = zAxis;

        Debug.Log(MousePosition);*/

        //transform.position = Input.mousePosition;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*if (Physics.Raycast(ray, out hit, 100, layerMask)) {
            //this.gameObject.transform.position = new Vector3(0f, 0f, hit.point.z);
            Debug.Log(hit.collider.name);

            if (hit.collider.name == "VR Cube")
            {
                if (!soundPlayingVR)
                {
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    soundPlayingVR = true;
                    soundPlayingMKB = false;
                }
            }
            else if (hit.collider.name == "MKB Cube")
            {
                if (!soundPlayingMKB)
                {
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    soundPlayingMKB = true;
                    soundPlayingVR = false;
                }
            }
            else if (hit.collider.name == "Trick Cube")
            {
                soundPlayingVR = false;
                soundPlayingMKB = false;
            }*/

            /*if (hit.collider.name == "VR")
            {
                hit.collider.GetComponent<AudioSource>().Play();
                Debug.Log("HIT ME BB");
            }

            if (hit.collider.name == "No VR")
                hit.collider.GetComponent<AudioSource>().Play();*/
        //}
    }

    public void PlayVRVoice()
    {
        if (!soundPlayingVR)
        {
            GameObject.Find("VR").GetComponent<AudioSource>().Play();
            //soundPlayingVR = true;
        }
    }

    public void StopVRVoice()
    {
        soundPlayingVR = false;
    }

    public void PlayMKBVoice()
    {
        if (!soundPlayingMKB)
        {
            GameObject.Find("No VR").GetComponent<AudioSource>().Play();
            //soundPlayingMKB = true;
        }
    }

    public void StopMKBVoice()
    {
        soundPlayingMKB = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "VR")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Test");
        }

        if (collision.name == "No VR")
            collision.gameObject.GetComponent<AudioSource>().Play();
    }

    public void VREnabled()
    {
        vrEnabled = true;
        LoadScene();
    }

    public void VRDisabled()
    {
        vrEnabled = false;
        LoadScene();
    }

    private void LoadScene()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);
    }
}
