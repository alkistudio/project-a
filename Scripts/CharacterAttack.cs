using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    [SerializeField] GridHighlight highlight;

    List<Vector2Int> attackPosition;

    /*private void Start()
    {
        CalculateAttackArea();
    }*/
    
    public void CalculateAttackArea(Vector2Int characterPositionOnGrid, int attackRange, bool allowSelfTarget = false)
    {
        if (attackPosition == null)
        {
            attackPosition = new List<Vector2Int>();
        }
        else 
        {
            attackPosition.Clear();
        }
        
        /*Character character = selectedCharacter.GetComponent<Character>();
        int attackRange = character.attackRange;

        attackPosition = new List<Vector2Int>();*/

        for (int x = -attackRange; x <= attackRange; x++)
        {
            for (int y = -attackRange; y <= attackRange; y++)
            {
                if (Mathf.Abs(x) + Mathf.Abs(y) > attackRange) { continue; }
                if (allowSelfTarget == false)
                {
                    if (x == 0 && y == 0) { continue; }
                }
                if (targetGrid.CheckBoundary(
                    characterPositionOnGrid.x + x, 
                    characterPositionOnGrid.y + y) 
                    == true)
                {
                    attackPosition.Add(new Vector2Int(
                        characterPositionOnGrid.x + x, 
                        characterPositionOnGrid.y + y));
                }

            }
        }
    
        highlight.Highlight(attackPosition);
    }
    public GridObject GetAttackTarget(Vector2Int mousePositionOnGrid)
    {
        GridObject target = targetGrid.GetPlacedObject(mousePositionOnGrid);
        return target;
    }

    public bool Check(Vector2Int mousePositionOnGrid)
    {
        return attackPosition.Contains(mousePositionOnGrid);
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, terrainLayerMask))
            {
                Vector2Int gridPosition = targetGrid.GetGridPosition(hit.point);

                if (attackPosition.Contains(gridPosition))
                {
                    GridObject gridObject = targetGrid.GetPlacedObject(gridPosition);
                    if (gridObject == null) { return; }
                    selectedCharacter.GetComponent<Attack>().AttackPosition(gridObject);
                }
            }
        }
    }*/
}
