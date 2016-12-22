using UnityEngine;
using System.Collections;

public class StoneGame_Movement : MonoBehaviour {

    private Vector3 lastMove = new Vector3(0, 0, 0);
    private bool move = false;
    public int counter = 0;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("moveableStone") && move)       
            gameObject.transform.position -= lastMove;

        move = false;
   }

    public void MoveUp()
    {
        lastMove = new Vector3(0, 0, -1f);
        ExecuteMove();
    }

    public void MoveDown() {
        lastMove = new Vector3(0, 0, 1f);
        ExecuteMove();
    }

    public void MoveLeft()
    {
        lastMove = new Vector3(1f, 0, 0);
        ExecuteMove();
    }

    public void MoveRight()
    {
        lastMove = new Vector3(-1f, 0, 0);
        ExecuteMove();
    }

    private void ExecuteMove()
    {
        move = true;
        counter++;
        gameObject.transform.position += lastMove;
    }
}    
