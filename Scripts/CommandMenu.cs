using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject moveButton;
    [SerializeField] GameObject attackButton;
    CommandInput commandInput;

    SelectCharacter selectCharacter;
    

    private void Awake()
    {
        commandInput = GetComponent<CommandInput>();
        selectCharacter = GetComponent<SelectCharacter>();
    }
    
    public void OpenPanel(CharacterTurn characterTurn)
    {
        selectCharacter.enabled = false;
        panel.SetActive(true);

        if(characterTurn.allegiance != Allegiance.Player)
        {
            moveButton.SetActive(false);
            attackButton.SetActive(false);
        }
        else
        {
            attackButton.SetActive(true);
            moveButton.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void MoveCommandSelected()
    {
        commandInput.SetCommandType(CommandType.MoveTo);
        commandInput.InitCommand();
        ClosePanel();
    }

    public void AttackCommandSelected()
    {
        commandInput.SetCommandType(CommandType.Attack);
        commandInput.InitCommand();
        ClosePanel();
    }

}
