using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drag_n_drop : MonoBehaviour {

    public int force;

    float posX;
    float posY;

    Vector3 start_pos;
    Vector3 dist;

    public Camera camera;

    private Rigidbody r;
    // Use this for initialization
    void Start () {
        r = gameObject.GetComponent<Rigidbody>();

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            transform.position = start_pos;
            r.velocity = Vector3.zero;
            r.useGravity = false;

        }
    }
    void OnMouseDown()
    {
        start_pos = transform.position;
        dist = camera.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;

    }

    void OnMouseDrag()
    {
        Vector3 curPos =
                  new Vector3(Input.mousePosition.x - posX,
                  Input.mousePosition.y - posY, dist.z);

        Vector3 worldPos = camera.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }

    void OnMouseUp()
    {
        r.velocity = (start_pos - transform.position) * force;
        r.useGravity = true;
    }
}
