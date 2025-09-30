using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    MouseInput mouseInput;
    CommandMenu commandMenu;

    private void Awake()
    {
        mouseInput = GetComponent<MouseInput>();
        commandMenu = GetComponent<CommandMenu>();
    }

    public Character selectedCharacter;
    GridObject gridObjectBeingHovered;
    public Character characterBeingHovered;
    Vector2Int mousePositionOnGrid = new Vector2Int(-1, -1);
    [SerializeField] Grid targetGrid;

    private void Update()
    {
        DetectHover();

        SelectCharacterFunction();

        DeselectCharacterFunction();
    }
    
    private void UpdatePanel()
    {
        if (selectedCharacter != null)
        {
            commandMenu.OpenPanel(selectedCharacter.GetComponent<CharacterTurn>());
        }
        else
        {
            commandMenu.ClosePanel();
        }
    }
    private void SelectCharacterFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (characterBeingHovered != null && selectedCharacter == null)
            {
                selectedCharacter = characterBeingHovered;
                
            }
            UpdatePanel();
        }
    }

    public void DeselectCharacterFunction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedCharacter = null;
            
        }
        UpdatePanel();
    }

    private void DetectHover()
    {
        if (mousePositionOnGrid != mouseInput.mousePositionOnGrid)
        {
            mousePositionOnGrid = mouseInput.mousePositionOnGrid;
            gridObjectBeingHovered = targetGrid.GetPlacedObject(mousePositionOnGrid);
            if (gridObjectBeingHovered != null)
            {
                characterBeingHovered = gridObjectBeingHovered.GetComponent<Character>();
            }
            else
            {
                characterBeingHovered = null;
            }
        }
    }
}
