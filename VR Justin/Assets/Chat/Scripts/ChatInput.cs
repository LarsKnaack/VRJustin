using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatInput : MonoBehaviour {

    public string inputText = "";
    GUIText VRCameraText;

    // Use this for initialization
    void Start () {
        VRCameraText = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GUIText>();
	}

    void OnGUI()
    {
        GUI.skin.textArea.fixedWidth = 30;
        inputText = GUILayout.TextArea(inputText, 200);
        if(GUILayout.Button("Send"))
        {
            VRCameraText.text = inputText;
            inputText = "";
        }
    }
}
