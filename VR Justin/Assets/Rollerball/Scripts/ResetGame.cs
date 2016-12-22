using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {

    public GameObject gamefield;
    public GameObject ball;

    private Vector3 start_pos;

    void Start()
    {
        start_pos = ball.transform.position;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ball")
        {
            gamefield.transform.rotation = Quaternion.Euler(0, 0, 0);
            ball.transform.position = start_pos;
            ball.transform.rotation = Quaternion.Euler(0, 0, 0);
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

}
