using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInput : MonoBehaviour {

    public GameObject gamefield;
    public float angle;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            gamefield.transform.Rotate(new Vector3(0, 0, -angle));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gamefield.transform.Rotate(new Vector3(-angle, 0, 0));
        }
    }
}
