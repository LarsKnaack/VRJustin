using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParticleCollision : MonoBehaviour {
    public int temperature;
    public bool isRunning = true;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision Detected!");
        if (!isRunning) return;
        WaterLogic logic = other.GetComponent<WaterLogic>();
        if(logic != null)
        {
            logic.AddTemperature(temperature);
        }
    }
}
