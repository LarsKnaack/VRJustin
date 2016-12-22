using UnityEngine;
using System.Collections;

public class ValveControl : MonoBehaviour {
    public float spinnedAngle = 0f;
    public float rotateBackTime = 2.0f;
    private float rotateSteps = 0f;
    private bool backRotateStat = false;
    public ParticleSystem ps;
    private ParticleSystem.EmissionModule em;
    bool rotated = false;
    Rigidbody rBody;
	// Use this for initialization
	void Start () {
	    if(ps != null)
        {
            em = ps.emission;
        }
        rBody = gameObject.GetComponent<Rigidbody>();
	}
        
	// Update is called once per frame
	void Update () {
	    if(backRotateStat)
        {
            if(spinnedAngle > 0)
            {
                float bckRt = rotateSteps * Time.deltaTime;
                Vector3 backRot = new Vector3(0, 0, -bckRt);
                gameObject.transform.Rotate(backRot);
                spinnedAngle -= bckRt;
                updateParticleSystem();
            }
            else
            {
                spinnedAngle = 0;
                backRotateStat = false;
                rotateSteps = 0;
                rotated = false;
            }
        }
	}

    public void rotateValve(float angle)
    {
        backRotateStat = false;
        Vector3 rot = rBody.rotation.eulerAngles;
        rot.z += angle * 55;
        Quaternion quatRot = Quaternion.Euler(rot);
        rBody.MoveRotation(quatRot);
        spinnedAngle += angle;
        updateParticleSystem();
    }

    public void updateParticleSystem()
    {
        float rateVal = spinnedAngle / 2;
        em.rate = rateVal;
    }

    public void rotateBack()
    {
       rotateSteps = (spinnedAngle / rotateBackTime);
       backRotateStat = true;
    }
}
