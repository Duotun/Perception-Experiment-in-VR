using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {
    public AudioClip pp;
    //public AudioClip throwsound;
    private SteamVR_TrackedObject trackedobj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedobj.index); }
    }
    void Awake()
    {
        trackedobj = GetComponent<SteamVR_TrackedObject>();
       
    }
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    private GameObject collidingObject;
    private GameObject objectInHand;
   
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerExit(Collider other)
    {
         if(!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        FixedJoint joint = addfixedJoint();
        //if (objectInHand != null)
       // {
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
         // }
    
    }
    private FixedJoint addfixedJoint()    //use for sticking together
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    private void releaseObject()
    {
         if(GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
            AudioSource.PlayClipAtPoint(pp, objectInHand.transform.position);
        }
        objectInHand = null;
    }
    // Update is called once per frame
    void Update()
    {
          if(Controller.GetHairTriggerDown())
        {
            GrabObject();
        }
        if(Controller.GetHairTriggerUp())
        {
             if(objectInHand)
            {
                releaseObject();
            }
        }
    }
}
