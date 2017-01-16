using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Fish : MonoBehaviour {

    private Rigidbody rigidbody;
    float direction;
    public float xSpace = 1;
    public float ySpace = 1;
    public float speed = 0.05f;

    private Vector3 updateVec;
    public float ymin, ymax, xmin, xmax;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 vel = new Vector3(0, 0, 1);
        
        Vector3 startPos = transform.position;
        Debug.Log(startPos);
        ymin = startPos.y - ySpace;
        ymax = startPos.y + ySpace;
        xmin = startPos.x - xSpace;
        xmax = startPos.x + xSpace;
        
        //direction = 1;
        updateVec = getUpdateVec();
        vel.x = updateVec.x * speed;
        vel.y = updateVec.y * speed;
        rigidbody.velocity = vel;
    }
	
    private Vector3 getUpdateVec()
    {
        float y = Random.Range(-ySpace, ySpace);
        float x = Random.Range(-xSpace, xSpace);
        return new Vector3(x, y, 0);
    }
	// Update is called once per frame
	void Update () {
        if (transform.position.x < xmin || transform.position.x > xmax ||
            transform.position.y < ymin || transform.position.y > ymax)
        {
            updateVec = getUpdateVec();
            Vector3 rVel = rigidbody.velocity;
            rVel.y = updateVec.y * speed;
            rVel.x = updateVec.x * speed;
            rigidbody.velocity = rVel;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.ToLower().Contains("controller"))
        {
            Debug.Log("Win");
            gameObject.layer = 0;
        }
        transform.Rotate(new Vector3(0,  0, 180));
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -rigidbody.velocity.z);
        //direction = -1;
        Debug.Log("Trigger");
    }
}
