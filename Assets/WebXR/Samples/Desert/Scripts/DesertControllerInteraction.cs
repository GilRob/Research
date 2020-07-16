using UnityEngine;
using System.Collections.Generic;
using WebXR;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(FixedJoint))]
[RequireComponent(typeof(WebXRController))]
public class DesertControllerInteraction : MonoBehaviour
{
    private FixedJoint attachJoint;
    private Rigidbody currentRigidBody;
    private List<Rigidbody> contactRigidBodies = new List<Rigidbody> ();
    private WebXRController controller;
    private Transform t;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    private Animator anim;

    //My additions
    private Goal goal;
    public GameObject spotLight;

    void Awake()
    {
        goal = GameObject.Find("Goal").GetComponent<Goal>();

        t = transform;
        attachJoint = GetComponent<FixedJoint> ();
        anim = GetComponent<Animator>();
        controller = GetComponent<WebXRController>();
    }

    void Update()
    {
        float normalizedTime = controller.GetButton("Trigger") ? 1 : controller.GetAxis("Grip");

        if (controller.GetButtonDown("Trigger") || controller.GetButtonDown("Grip"))
            Pickup();

        if (controller.GetButtonUp("Trigger") || controller.GetButtonUp("Grip"))
            Drop();

        // Use the controller button or axis position to manipulate the playback time for hand model.
        anim.Play("Take", -1, normalizedTime);
    }

    void FixedUpdate()
    {
        if (!currentRigidBody) return;
        
        lastPosition = currentRigidBody.position;
        lastRotation = currentRigidBody.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        //Used to be the "Interactable" tag
        if (!other.gameObject.CompareTag("Pickup"))
            return;

        contactRigidBodies.Add(other.attachedRigidbody);
    }

    void OnTriggerExit(Collider other)
    {
        //Used to be the "Interactable" tag
        if (!other.gameObject.CompareTag("Pickup"))
            return;

        contactRigidBodies.Remove(other.attachedRigidbody);
    }

    public void Pickup() {
        currentRigidBody = GetNearestRigidBody ();

        if (!currentRigidBody)
            return;

        //My additions
        spotLight.transform.position = new Vector3(0.739f, 8.13f, -28.86f);
        spotLight.GetComponent<Light>().spotAngle = 60;

        //currentRigidBody.GetComponent<Rigidbody>().isKinematic = true;
        //

        //Goal sound stuff
        goal.source.Stop();
        goal.source.loop = true;
        goal.source.clip = goal.clipList[0];
        goal.source.Play();
        //

        //Object sound stuff - my addition
        currentRigidBody.GetComponentInChildren<AudioSource>().Stop();
        //

        currentRigidBody.MovePosition(t.position);
        attachJoint.connectedBody = currentRigidBody;
        
        lastPosition = currentRigidBody.position;
        lastRotation = currentRigidBody.rotation;
    }

    public void Drop() {

        if (!currentRigidBody)
            return;

        //My additions
        spotLight.transform.position = new Vector3(currentRigidBody.transform.position.x, 8.13f, currentRigidBody.transform.position.z);
        spotLight.GetComponent<Light>().spotAngle = 30;

        //currentRigidBody.GetComponent<Rigidbody>().isKinematic = false;

        //Goal sound stuff
        goal.source.Stop();

        currentRigidBody.GetComponentInChildren<AudioSource>().Play();
        //

        attachJoint.connectedBody = null;
        
        currentRigidBody.velocity = (currentRigidBody.position - lastPosition) / Time.deltaTime;
        
        var deltaRotation = currentRigidBody.rotation * Quaternion.Inverse(lastRotation);
        float angle;
        Vector3 axis;
        deltaRotation.ToAngleAxis(out angle, out axis);
        angle *= Mathf.Deg2Rad;
        currentRigidBody.angularVelocity = axis * angle / Time.deltaTime;
        
        currentRigidBody = null;
    }

    private Rigidbody GetNearestRigidBody() {
        Rigidbody nearestRigidBody = null;
        float minDistance = float.MaxValue;
        float distance;

        foreach (Rigidbody contactBody in contactRigidBodies) {
            distance = (contactBody.transform.position - t.position).sqrMagnitude;

            if (distance < minDistance) {
                minDistance = distance;
                nearestRigidBody = contactBody;
            }
        }

        return nearestRigidBody;
    }
}
