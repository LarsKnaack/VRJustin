using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Fish : MonoBehaviour {

    private Rigidbody rigidbody;
    float direction;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0, 0, 1);
        //direction = 1;
	}
	
	// Update is called once per frame
	void Update () {

	}



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.ToLower().Contains("controller"))
        {
            Debug.Log("Win");
        }
        transform.Rotate(new Vector3(0,  0, 180));
        rigidbody.velocity = new Vector3(0, 0, -rigidbody.velocity.z);
        //direction = -1;
        Debug.Log("Trigger");
    }
}
