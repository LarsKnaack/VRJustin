using UnityEngine;
using System.Collections;

public class ControllerLogic : MonoBehaviour {
    Vector3 oldPos;
    Controller controller;
    Vector3 mov;
	// Use this for initialization
	void Start () {
        controller = transform.parent.GetComponent<Controller>();
        oldPos = gameObject.transform.position;
	}

    private void FixedUpdate()
    {
        mov = gameObject.transform.position - oldPos;
        mov.x *= -1;
        oldPos = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Valve")
        {
            Vector3 collCenter = other.attachedRigidbody.position;
            Vector3 rBodyForward = other.attachedRigidbody.transform.forward;
            Vector3 dist = collCenter - oldPos;
            Vector2 move = new Vector2(mov.x, mov.y);
            int sign = 1;
            /*
            if (transform.forward.z > 0)
            {
                sign *= -1;
            }
            */
            float movelength = mov.magnitude;
            
            ValveControl vControl = other.gameObject.GetComponent<ValveControl>();
            if (controller.triggerIsPressed)
            {
                if (movelength != 0)
                    vControl.rotateValve(movelength * sign);
            }
            else
            {
                vControl.rotateBack();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Valve")
        {
            other.gameObject.GetComponent<ValveControl>().rotateBack();
        }
    }
}
