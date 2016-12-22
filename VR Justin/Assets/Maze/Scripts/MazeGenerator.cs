using UnityEngine;
using System.Collections.Generic;

public enum Direction
{
    Start,
    Right,
    Front,
    Left,
    Back,
};

public class MazeCell
{
    public bool IsVisited = false;
    public bool WallRight = false;
    public bool WallFront = false;
    public bool WallLeft = false;
    public bool WallBack = false;
}

public class MazeGenerator : MonoBehaviour
{

    public int rows;
    public int columns;

    public GameObject Wall;
    public GameObject Floor;

    private int cellsize = 4;
    private MazeCell[,] mazeCell;
    
    void Start()
    {
        mazeCell = new MazeCell[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                mazeCell[row, column] = new MazeCell();
            }
        }

        GenerateMaze(0, 0, Direction.Start);
        CreateMaze();
    }

    private void GenerateMaze(int row, int column, Direction move)
    {
        Direction[] possibleMoves = new Direction[4];
        int movesCount = 0;

        do
        {
            movesCount = 0;

            //check move right
            if (column + 1 < columns && !mazeCell[row, column + 1].IsVisited)
            {
                possibleMoves[movesCount] = Direction.Right;
                movesCount++;
            }
            else if (!mazeCell[row, column].IsVisited && move != Direction.Left)
            {
                mazeCell[row, column].WallRight = true;
            }

            //check move forward
            if (row + 1 < rows && !mazeCell[row + 1, column].IsVisited)
            {
                possibleMoves[movesCount] = Direction.Front;
                movesCount++;
            }
            else if (!mazeCell[row, column].IsVisited && move != Direction.Back)
            {
                mazeCell[row, column].WallFront = true;
            }


            //check move left
            if (column > 0 && column - 1 >= 0 && !mazeCell[row, column - 1].IsVisited)
            {
                possibleMoves[movesCount] = Direction.Left;
                movesCount++;
            }
            else if (!mazeCell[row, column].IsVisited && move != Direction.Right)
            {
                mazeCell[row, column].WallLeft = true;
            }
            //check move backward
            if (row > 0 && row - 1 >= 0 && !mazeCell[row - 1, column].IsVisited)
            {
                possibleMoves[movesCount] = Direction.Back;
                movesCount++;
            }
            else if (!mazeCell[row, column].IsVisited && move != Direction.Front)
            {
                mazeCell[row, column].WallBack = true;
            }

            mazeCell[row, column].IsVisited = true;

            if (movesCount > 0)
            {
                switch (possibleMoves[Random.Range(0, movesCount)])
                {
                    case Direction.Right:
                        GenerateMaze(row, column + 1, Direction.Right);
                        break;
                    case Direction.Front:
                        GenerateMaze(row + 1, column, Direction.Front);
                        break;
                    case Direction.Left:
                        GenerateMaze(row, column - 1, Direction.Left);
                        break;
                    case Direction.Back:
                        GenerateMaze(row - 1, column, Direction.Back);
                        break;
                }
            }

        } while (movesCount > 0);
    }

    private void CreateMaze()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                float x = column * cellsize;
                float z = row * cellsize;
                MazeCell cell = mazeCell[row, column];
                GameObject tmp;
                tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                tmp.transform.parent = transform;
                //tmp = Instantiate(Floor, new Vector3(x, 3, z), Quaternion.Euler(180, 0, 0)) as GameObject;
                //tmp.transform.parent = transform;
                if (cell.WallRight)
                {
                    tmp = Instantiate(Wall, new Vector3(x + cellsize / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right
                    tmp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z + cellsize / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// front
                    tmp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    tmp = Instantiate(Wall, new Vector3(x - cellsize / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
                    tmp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z - cellsize / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// back
                    tmp.transform.parent = transform;
                }
            }
        }
    }
}

