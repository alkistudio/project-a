using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] Grid targetGrid;

    Pathfinding pathfinding;
    [SerializeField] GridHighlight gridHighlight;


    private void Start()
    {
        pathfinding = targetGrid.GetComponent<Pathfinding>();
        
    }

    public void CheckWalkableTerrain(Character targetCharacter)
    {
        GridObject gridObject = targetCharacter.GetComponent<GridObject>();
        List<PathNode> walkableNodes = new List<PathNode>();
        pathfinding.Clear();
        pathfinding.CalculateWalkableNodes(
            gridObject.positionOnGrid.x, 
            gridObject.positionOnGrid.y,
            targetCharacter.GetComponent<CharacterTurn>().actionPointsLeft, 
            ref walkableNodes
            );
        gridHighlight.Hide();

        gridHighlight.Highlight(walkableNodes);
    }

    public List<PathNode> GetPath(Vector2Int from)
    {
        //path = pathfinding.FindPath(targetCharacter.positionOnGrid.x, targetCharacter.positionOnGrid.y, gridPosition.x, gridPosition.y);
        List<PathNode> path = pathfinding.TraceBackPath(from.x, from.y);
        
        if (path == null) { return null; }
        if (path.Count == 0) { return null; }
        path.Reverse();

        return path;
    }

}
