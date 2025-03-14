using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public Grid targetGrid;
    public Vector2Int positionOnGrid;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        positionOnGrid = targetGrid.GetGridPosition(transform.position);
        Debug.Log($"The position is {transform.position}");
        Debug.Log($"The object is {this}");
        targetGrid.PlaceObject(positionOnGrid, this);
        Vector3 pos = targetGrid.GetWorldPosition(positionOnGrid.x, positionOnGrid.y, true);
        transform.position = pos;
    }
}
