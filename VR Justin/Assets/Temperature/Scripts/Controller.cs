using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    public bool triggerIsPressed = false;
	// Use this for initialization
	void Start () {
        trackedObj = gameObject.GetComponent<SteamVR_TrackedObject>();
	}

    private void FixedUpdate()
    {
        SteamVR_Controller.Device controller = SteamVR_Controller.Input((int)trackedObj.index);
        triggerIsPressed = controller.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
