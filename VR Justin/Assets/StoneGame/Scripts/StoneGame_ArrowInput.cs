using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class StoneGame_ArrowInput : MonoBehaviour
{

    private LinkedList<StoneGame_Movement> moves = new LinkedList<StoneGame_Movement>();
    private Material arrow;
    private Material highlight;

    // Use this for initialization
    [MenuItem("AssetDatabase/LoadAssetExample")]
    void Start()
    {
        GameObject[] moveableStones = GameObject.FindGameObjectsWithTag("moveableStone");
        foreach (GameObject stone in moveableStones)
        {
            moves.AddLast(stone.GetComponent<StoneGame_Movement>());
        }

        arrow = (Material)AssetDatabase.LoadAssetAtPath("Assets/StoneGame/Materials/Materials/arrow_up.mat", typeof(Material));
        highlight = (Material)AssetDatabase.LoadAssetAtPath("Assets/StoneGame/Materials/Materials/arrow_up_highlight.mat", typeof(Material));
    }


    void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        gameObject.GetComponent<Renderer>().material = highlight;
        foreach (StoneGame_Movement script in moves)
        {
            switch (tag)
            {
                case "moveUp": script.MoveUp(); Debug.Log("UP"); break;
                case "moveDown": script.MoveDown(); Debug.Log("DOWN"); break;
                case "moveLeft": script.MoveLeft(); Debug.Log("LEFT"); break;
                case "moveRight": script.MoveRight(); Debug.Log("RIGHT"); break;
            }
        }
    }

    void OnTriggerExit()
    {
        gameObject.GetComponent<Renderer>().material = arrow;
    }
}
