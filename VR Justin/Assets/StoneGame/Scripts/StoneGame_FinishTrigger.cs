using UnityEngine;
using System.Collections;

public class StoneGame_FinishTrigger : MonoBehaviour {

    public bool finish = false;

    void OnTriggerEnter()
    {
        finish = true;
    }

    void OnTriggerExit()
    {
        finish = false;
    }

}
