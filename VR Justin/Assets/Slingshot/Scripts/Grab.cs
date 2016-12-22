using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public GameObject con;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    // Use this for initialization
    void Start () {
        trackedObj = con.GetComponent<SteamVR_TrackedObject>();
    }
	
    void OnCollisionEnter(Collision other)
    {
        if (controller.GetPress(triggerButton))
        {
            other.transform.parent = con.transform;
            Debug.Log("Pressed");
        }
    }
}
