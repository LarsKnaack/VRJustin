using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoneGame_GameControll: MonoBehaviour {

    public StoneGame_Movement movement;
    private LinkedList<StoneGame_FinishTrigger> triggers = new LinkedList<StoneGame_FinishTrigger>();

	// Use this for initialization
	void Start () {
        GameObject[] finishFields = GameObject.FindGameObjectsWithTag("finishField");

        
        foreach(GameObject field in finishFields)
        {
            triggers.AddLast(field.GetComponent<StoneGame_FinishTrigger>());
        }
	}
	
	// Update is called once per frame
	void Update () {

        bool test = true;

	    foreach(StoneGame_FinishTrigger script in triggers)
        {
            test = test && script.finish;
        }

        if (test)
        {
            Debug.Log("Game finished! Datatataaaaaa");
            Debug.Log(movement.counter + "moves!");
        }
	}
}
