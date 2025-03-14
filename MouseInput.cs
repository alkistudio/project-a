using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Grid targetGrid;
    [SerializeField] LayerMask terrainLayerMask;

    public Vector2Int mousePositionOnGrid;
    public bool active;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, terrainLayerMask))
        {
            active = true;
            Vector2Int hitPosition = targetGrid.GetGridPosition(hit.point);
            if (hitPosition != mousePositionOnGrid)
            {
                mousePositionOnGrid = hitPosition;
            }
        
        }
        else 
        { 
            active = false; 
        }
    }
}
