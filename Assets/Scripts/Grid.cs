using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.Mathematics;

public class Grid : MonoBehaviour
{
    public int width;
    public int height;
    public int cellSize;
    public int[,] gridArray;
    public Transform debugGridObjectPrefab;
    public TextMesh[,] debugTextArray;

    public GameObject prefabs;

    public Grid(int width, int height, int cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                debugTextArray[i, j] = UtilsClass.CreateWorldText(gridArray[i, j].ToString(), null, GetWorldPostition(i, j) + new Vector3(cellSize, cellSize) * 0.5f, 30, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPostition(i, j), GetWorldPostition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPostition(i, j), GetWorldPostition(i + 1, j), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPostition(0, height), GetWorldPostition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPostition(width, 0), GetWorldPostition(width, height), Color.white, 100f);
        SetValue(2, 1, 85);
    }

    public Vector3 GetWorldPostition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < width)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

}
