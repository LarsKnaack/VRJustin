using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour {
    public static double temperature = 0;
    public int targetTemp;
    public RawImage temperature_arrow;
    public float winCountdown = 5.0f;
    public AudioSource audio;
    public bool audioPlayed = false;

    private void Start()
    {
        targetTemp = UnityEngine.Random.Range(10, 90);
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        double degree = 45 + 180 * ((temperature - 10)/-80);
        if(temperature_arrow != null)
            temperature_arrow.rectTransform.eulerAngles = new Vector3(0, temperature_arrow.rectTransform.eulerAngles.y, (float)degree);
        checkTemp();
        if (winCountdown <= 0 && !audioPlayed)
        {
            audio.Play();
            audioPlayed = true;
        }
    }

    void checkTemp()
    {
        if(temperature < targetTemp - 1)
        {
            temperature_arrow.color = Color.red;
            winCountdown = 5.0f;
        } else if(temperature > targetTemp + 1)
        {
            temperature_arrow.color = Color.blue;
            winCountdown = 5.0f;
        } else
        {
            temperature_arrow.color = Color.green;
            winCountdown -= Time.deltaTime;
        }
    }

}
