using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVision : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    public List<Vector2Int> visiblePosition;
    public void CalculateVisionArea(Vector2Int characterPositionOnGrid, int visionRange, bool allowSelfVisible = true)
    {
        if (visiblePosition == null)
        {
            visiblePosition = new List<Vector2Int>();
        }
        else 
        {
            //visiblePosition.Clear();
        }

        for (int x = -visionRange; x <= visionRange; x++)
        {
            for (int y = -visionRange; y <= visionRange; y++)
            {
                if (Mathf.Abs(x) + Mathf.Abs(y) > visionRange) { continue; }
                if (allowSelfVisible == false)
                {
                    if (x == 0 && y == 0) { continue; }
                }
                if (targetGrid.CheckBoundary(
                    characterPositionOnGrid.x + x,
                    characterPositionOnGrid.y + y)
                    == true)
                {
                    visiblePosition.Add(new Vector2Int(
                        characterPositionOnGrid.x + x,
                        characterPositionOnGrid.y + y));
                    
                }

            }
        }
        
        //highlight.Highlight(visiblePosition);
    }
}
