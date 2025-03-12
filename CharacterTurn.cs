using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurn : MonoBehaviour
{
    public float actionPointsLeft;

    private void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        actionPointsLeft = GetComponent<Character>().actionPoints;
    }
}
