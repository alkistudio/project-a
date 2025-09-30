using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    [SerializeField] LayerMask terrainLayerMask;
    [SerializeField] GridObject hoveringOver;
    [SerializeField] SelectableGridObject selectedObject;

    Vector2Int currentGridPosition = new Vector2Int(-1,-1);

    //Pathfinding pathfinding;
    //Vector2Int currentPosition = new Vector2Int();
    //List<PathNode> path;
    /*
    private void Start()
    {
        pathfinding = targetGrid.GetComponent<Pathfinding>();
    }
    */

    private void Update()
    {
        GetMouseIntersect();
            
        SelectObject();
        DeselectObject();
        
    }

    private void SelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hoveringOver == null) { return; }
            selectedObject = hoveringOver.GetComponent<SelectableGridObject>();
        }
    }

    private void DeselectObject()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            selectedObject = null;
        }
    }

    /*
    private void OnDrawGizmos()
    {
        if (path == null) { return; }
        if (path.Count == 0) { return; }

        for (int i = 0; i < path.Count - 1; i++)
        {
            Gizmos.DrawLine(targetGrid.GetWorldPosition(path[i].pos_x, path[i].pos_y, true), targetGrid.GetWorldPosition(path[i + 1].pos_x, path[i + 1].pos_y, true));
        }
    }
    */
    private void GetMouseIntersect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, terrainLayerMask))
            {
                Vector2Int gridPosition = targetGrid.GetGridPosition(hit.point);
                if (gridPosition == currentGridPosition) { return; }
                currentGridPosition = gridPosition;
                GridObject gridObject = targetGrid.GetPlacedObject(gridPosition);
                hoveringOver = gridObject;

                //path = pathfinding.FindPath(currentPosition.x, currentPosition.y, gridPosition.x, gridPosition.y);
                
                //currentPosition = gridPosition;
                /*
                GridObject gridObject = targetGrid.GetPlacedObject(gridPosition);
                Debug.Log(gridObject);
                if (gridObject == null)
                {
                    Debug.Log("x=" + gridPosition.x + "y=" + gridPosition.y + "is empty");
                }
                else {
                    Debug.Log("x=" + gridPosition.x + "y=" + gridPosition.y + gridObject.GetComponent<Character>().Name);
                }*/


            }
    }
}
