using UnityEngine;
using System.Collections;

public class StoneGame_Foots : MonoBehaviour {

    private GameObject cam;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(cam.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        gameObject.transform.position = pos;
    }
}
