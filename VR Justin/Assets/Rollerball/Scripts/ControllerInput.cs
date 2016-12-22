using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private SteamVR_TrackedController trackedController;
    private SteamVR_Controller.Device device;

    public GameObject gamefield;

    public float angle;
    
    void Start()
    {
        trackedController = GetComponent<SteamVR_TrackedController>();

        trackedController.TriggerClicked += Trigger;
        trackedController.PadTouched += PadTouched;
    }

    void Update()
    {
        if (trackedController.padTouched)
        {   
            if(gameObject.name.Contains("left"))
            {
                gamefield.transform.Rotate(new Vector3(angle, 0, 0));
            } else
            {
                gamefield.transform.Rotate(new Vector3(0, 0, angle));
            }                
        }
    }

    private void PadTouched(object sender, ClickedEventArgs e)
    {
        device = SteamVR_Controller.Input((int)e.controllerIndex);
    }

    void Trigger(object sender, ClickedEventArgs e)
    {
        gamefield.transform.Rotate(new Vector3(angle, 0, 0));
    }
}
