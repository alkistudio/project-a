using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] ForceContainer playerForceContainer;
    [SerializeField] ForceContainer opponentForceContainer;
    int round = 1;

    private void Start()
    {
        UpdateTextOnScreen();
    }

    [SerializeField] TMPro.TextMeshProUGUI turnCountText;
    [SerializeField] TMPro.TextMeshProUGUI forceRoundText;

    public void AddMe(CharacterTurn character)
    {
        if (character.allegiance == Allegiance.Player)
        {
            playerForceContainer.AddMe(character);
        }
        if (character.allegiance == Allegiance.Enemy)
        {
            opponentForceContainer.AddMe(character);
        }
    }

    Allegiance currentTurn;

    public void NextTurn()
    {
        switch (currentTurn)
        {
            case Allegiance.Player:
                currentTurn = Allegiance.Enemy;
                break;
            case Allegiance.Enemy:
                NextRound();
                currentTurn = Allegiance.Player;
                break;
        }

        GrantTurnToForce();

        UpdateTextOnScreen();
    }

    private void GrantTurnToForce()
    {
        switch(currentTurn)
        {
            case Allegiance.Player:
                playerForceContainer.GrantTurn();
                break;
            case Allegiance.Enemy:
                opponentForceContainer.GrantTurn();
                break;
        }
    }

    public void NextRound()
    {
        round += 1;


    }

    void UpdateTextOnScreen()
    {
        turnCountText.text = "Turn: " + round.ToString();
        forceRoundText.text = currentTurn.ToString() + "'s Turn";
    }
}
