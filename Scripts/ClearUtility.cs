using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUtility : MonoBehaviour
{
    [SerializeField] Pathfinding targetPathfinding;
    [SerializeField] GridHighlight attackHighlight;
    [SerializeField] GridHighlight moveHighlight;

    public void ClearPathfinding()
    {
        targetPathfinding.Clear();
    }

    public void ClearAttackHighlight()
    {
        attackHighlight.Hide();
    }

    public void ClearMoveHighlight()
    {
        moveHighlight.Hide();
    }
}
