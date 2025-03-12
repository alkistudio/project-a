using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommandType
{
    MoveTo,
    Attack
}

public class Command
{
    public Character character;
    public Vector2Int selectedGrid;
    public CommandType commandType;

    public Command(Character character, Vector2Int selectedGrid, CommandType commandType)
    {
        this.character = character;
        this.selectedGrid = selectedGrid;
        this.commandType = commandType;
    }

    public List<PathNode> path;
    public GridObject target;
}

public class CommandManager : MonoBehaviour
{
    Command currentCommand;

    [SerializeField] Grid grid;
    ClearUtility clearUtility;

    CommandInput commandInput;

    private void Awake()
    {
        clearUtility = GetComponent<ClearUtility>();
    }
    private void Start()
    {
        commandInput = GetComponent<CommandInput>();
    }

    private void Update()
    {
        if (currentCommand != null)
        {
            ExecuteCommand();
        }
    }
    public void AddMoveCommand(Character character, Vector2Int selectedGrid, List<PathNode> path)
    {
        currentCommand = new Command(character, selectedGrid, CommandType.MoveTo);
        currentCommand.path = path;
    }

    public void ExecuteCommand()
    {
        switch (currentCommand.commandType)
        {
            case CommandType.MoveTo:
                MovementCommandExecute();
                break;
            case CommandType.Attack:
                AttackCommandExecute();

                break;
        }
    }

    private void AttackCommandExecute()
    {
        Character receiver = currentCommand.character;
        Debug.Log("the target is" + currentCommand.target);
        receiver.GetComponent<Attack>().AttackPosition(currentCommand.target);
        receiver.GetComponent<CharacterTurn>().actionPointsLeft -= receiver.attackCostAP;
        currentCommand = null;
        clearUtility.ClearAttackHighlight();

    }


    private void MovementCommandExecute()
    {
        Character receiver = currentCommand.character;
        receiver.GetComponent<Movement>().Move(currentCommand.path);
        receiver.GetComponent<CharacterTurn>().actionPointsLeft -= grid.GetComponent<Pathfinding>().CalculateDistance(currentCommand.path[0], currentCommand.path[currentCommand.path.Count-1]);
        currentCommand = null;
        clearUtility.ClearPathfinding();
        clearUtility.ClearMoveHighlight();
    }

    public void AddAttackCommand(Character attacker, Vector2Int mousePositionOnGrid, GridObject target)
    {
        currentCommand = new Command(attacker, mousePositionOnGrid, CommandType.Attack);
        currentCommand.target = target;

    }

    public void CancelCommand()
    {
        currentCommand = null;
    }
}
