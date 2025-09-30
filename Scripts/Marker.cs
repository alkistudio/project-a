using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] Transform marker;
    MouseInput mouseInput;
    Vector2Int currentMousePosition;
    bool active;
    [SerializeField] Grid targetGrid;
    [SerializeField] float markerElevation = 0f;

    

    private void Awake()
    {
        mouseInput = GetComponent<MouseInput>();
    }

    private void Update()
    {
        if (active != mouseInput.active) 
        {
            active = mouseInput.active;
            
            marker.gameObject.SetActive(active);
        }
        if (active == false) { return; }
        if (currentMousePosition != mouseInput.mousePositionOnGrid)
        {
            currentMousePosition = mouseInput.mousePositionOnGrid;
            UpdateMarker();
        }
        
    }

    private void UpdateMarker()
    {
        if (targetGrid.CheckBoundary(currentMousePosition) == false) { return; }
        Vector3 worldPosition = targetGrid.GetWorldPosition(currentMousePosition.x, currentMousePosition.y, true);
        worldPosition.y += markerElevation;
        marker.position = worldPosition;
    }
}
