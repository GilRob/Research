using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    //Variables
    private GameObject playerCamera;
    private GameObject carriedObj;
    public Image reticle;

    private bool isCarrying;

    public float distance;
    public float smoother;

    private Goal goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Goal>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
        reticle = reticle.GetComponent<Image>();
        isCarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarrying)
        {
            CarryObject(carriedObj);
            DropObject();
        }
        else
        {
            PickupObject();
        }
    }

    private void CarryObject(GameObject obj)
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, playerCamera.transform.position + playerCamera.transform.forward * distance, Time.deltaTime * smoother);
    }

    private void PickupObject()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y, 0.0f));
        RaycastHit hit;

        //Change reticle colour for detection
        if (Physics.Raycast(ray, out hit, 4))
        {
            if (hit.collider.tag == "Pickup")
                reticle.color = Color.green;
            else
                reticle.color = Color.white;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "Pickup")
                {
                    isCarrying = true;
                    carriedObj = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    //Object sound stuff
                    carriedObj.GetComponentInChildren<AudioSource>().Stop();
                    //Goal sound stuff
                    goal.source.Stop();
                    goal.source.loop = true;
                    goal.source.clip = goal.clipList[0];
                    goal.source.Play();
                }
            }

        }
    }

    private void DropObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isCarrying = false;
            carriedObj.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            carriedObj.GetComponentInChildren<AudioSource>().Play();
            carriedObj = null;

            //Goal sound stuff
            goal.source.Stop();
        }
    }
}
