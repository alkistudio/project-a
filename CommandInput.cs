using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInput : MonoBehaviour
{
    CommandManager commandManager;
    MouseInput mouseInput;
    MoveCharacter moveCharacter;
    CharacterAttack characterAttack;
    SelectCharacter selectCharacter;

    public void Awake()
    {
        commandManager = GetComponent<CommandManager>();
        mouseInput = GetComponent<MouseInput>();
        moveCharacter = GetComponent<MoveCharacter>();
        characterAttack = GetComponent<CharacterAttack>();
        selectCharacter = GetComponent<SelectCharacter>();
    }

    
    [SerializeField] CommandType currentCommand;
    bool isCommandInput;

    public void SetCommandType(CommandType commandType)
    {
        currentCommand = commandType;
    }

    public void InitCommand()
    {
        isCommandInput = true;
        switch (currentCommand)
        {
            case CommandType.MoveTo:
                HighlightWalkableTerrain();
                break;
            case CommandType.Attack:
                characterAttack.CalculateAttackArea(
                    selectCharacter.selectedCharacter.GetComponent<GridObject>().positionOnGrid, 
                    selectCharacter.selectedCharacter.attackRange
                    );
                break;
        }
    }
    
    private void Start()
    {
        /*HighlightWalkableTerrain();
        characterAttack.CalculateAttackArea(
            selectedCharacter.GetComponent<GridObject>().positionOnGrid, 
            selectedCharacter.attackRange
            );*/
    }


    private void MoveCommandInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<PathNode> path = moveCharacter.GetPath(mouseInput.mousePositionOnGrid);
            if (path == null) { return; }
            //if (!moveCharacter.publicWalkableNodes.Contains(path[path.Count-1])) { return; }
            if (path.Count == 0) { return; }
            commandManager.AddMoveCommand(selectCharacter.selectedCharacter, mouseInput.mousePositionOnGrid, path);
            //selectCharacter.DeselectCharacterFunction();
            selectCharacter.enabled = true;
            selectCharacter.selectedCharacter = null;
            isCommandInput = false;
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            //selectCharacter.selectedCharacter.GetComponent<Movement>().SkipAnimation();
        }
    }

    private void AttackCommandInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (characterAttack.Check(mouseInput.mousePositionOnGrid) == true)
            {
                if (selectCharacter.selectedCharacter.GetComponent<CharacterTurn>().actionPointsLeft - selectCharacter.selectedCharacter.GetComponent<Character>().attackCostAP >= 0)
                {
                    GridObject gridObject = characterAttack.GetAttackTarget(mouseInput.mousePositionOnGrid);
                    if (gridObject == null) { return; }
                    commandManager.AddAttackCommand(selectCharacter.selectedCharacter, mouseInput.mousePositionOnGrid, gridObject);
                    //selectCharacter.DeselectCharacterFunction();
                    selectCharacter.enabled = true;
                    selectCharacter.selectedCharacter = null;
                    isCommandInput = false;
                }              
                
                
            }
        }
    }

    private void Update()
    {
        if (isCommandInput == false) { return; }
        switch (currentCommand)
        {
            case CommandType.MoveTo:
                MoveCommandInput();
                break;
            case CommandType.Attack:
                AttackCommandInput();
                break;
        }
        //Debug.Log(currentCommand);
    }

    public void HighlightWalkableTerrain()
    {
        moveCharacter.CheckWalkableTerrain(selectCharacter.selectedCharacter);
    }

    public void Deselect()
    {
        selectCharacter.selectedCharacter = null;
        selectCharacter.enabled = true;
    }
}
