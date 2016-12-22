using UnityEngine;
using System.Collections;

public class Lightspawner : MonoBehaviour {

    void OnTriggerEnter()
    {
        gameObject.GetComponentInChildren<Light>().enabled = true;
    }
}
