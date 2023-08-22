using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Testing : MonoBehaviour
{
    public Grid grid;
    private void Start()
    {
        grid = new Grid(4, 2, 5);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 85);
        }
    }
}
