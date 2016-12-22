using UnityEngine;
using System.Collections;

public class ValveTest : MonoBehaviour {
    public ValveControl control;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.D))
        {
            if(control != null)
            {
                control.rotateValve(10 * Time.deltaTime);
            }
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            if(control != null)
            {
                control.rotateBack();
            }
        }

	}
}
