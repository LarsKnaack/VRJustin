using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {
        
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject trackedObj;

    public GameObject parent;
    private new GameObject camera;

    private const float SPEED = 5;

    private SteamVR_Controller.Device controller {
        get {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	

	void Update () {

	    if (controller == null)
        {
            Debug.Log("Controller not initalized");
            return;
        }
       
        if (controller.GetPress(triggerButton) && parent != null)
        {
            float y = parent.transform.position.y;
            parent.transform.position = parent.transform.position + camera.transform.forward * SPEED * Time.deltaTime;
            float x = parent.transform.position.x;
            float z = parent.transform.position.z;
            parent.transform.position = new Vector3(x, y, z);
        }
	}
}
