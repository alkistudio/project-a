using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Allegiance
{
    Player,
    Ally,
    Enemy
}
public class CharacterTurn : MonoBehaviour
{
    public Allegiance allegiance;
    public float actionPointsLeft;

    private void Start()
    {
        AddToRoundManager();
        StartTurn();
    }

    public void StartTurn()
    {
        actionPointsLeft = GetComponent<Character>().actionPoints;
    }

    private void AddToRoundManager()
    {
        RoundManager.instance.AddMe(this);
    }
}
