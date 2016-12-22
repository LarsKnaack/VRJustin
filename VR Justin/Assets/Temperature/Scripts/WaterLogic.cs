using UnityEngine;
using System.Collections;

public class WaterLogic : MonoBehaviour {
    public float temperature = 0;
    public int totalParticles = 0;

    public float maxHeight;
    private float startHeight;
    bool fleedOut = false;
    int particleStep;
    float fleedCountDown;
    public float fleedCountDownDefVal = 2.0f;
    public int particlePerSecond;
    public float heightSteps = 0.01f;
    private int particleFleedCount;
	// Use this for initialization
	void Start () {
        fleedCountDown = fleedCountDownDefVal;
        startHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(fleedCountDown > 0)
        {
            fleedCountDown -= Time.deltaTime;
            return;
        }
        //Countdown abgelaufen
        if (fleedCountDown <= 0 && fleedOut == false)
        {
            fleedOut = true;
            particleFleedCount = (int)(totalParticles / (transform.position.y - startHeight));
        }
        //Abfluss
        if (fleedOut && transform.position.y > startHeight)
        {
            transform.Translate(0, -heightSteps * particlePerSecond * Time.deltaTime, 0);
            totalParticles -= (int)(particleFleedCount * Time.deltaTime);
            if (transform.position.y < startHeight) {
                fleedOut = false;
                transform.position = new Vector3(transform.position.x, startHeight, transform.position.z);
                totalParticles = 0;
                temperature = 0;
            }
        }
	}
    
    public void AddTemperature(int temp)
    {
        temperature = ((totalParticles * temperature) + temp) / (totalParticles + 1);
        totalParticles++;
        Manager.temperature = temperature;
        fleedOut = false;
        fleedCountDown = fleedCountDownDefVal;
        if(transform.position.y + heightSteps < maxHeight)
        {
            transform.Translate(0, heightSteps, 0);
        }
        
    }
}
