using UnityEngine;
using System.Collections;

public class Appear_Zombie : MonoBehaviour {

    public GameObject mesh;
    public BoxCollider col;
    public AudioSource audio_sour;
	
    void OnTriggerEnter(Collider other)
    {
        mesh.SetActive(true);
        Debug.Log(other.name);
        audio_sour.Play();
    }

}
