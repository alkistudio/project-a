using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterVisionIndividual : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] Grid grid;
    CharacterVision characterVision;
    Character character;
    void Awake()
    {
        characterVision = gameManager.GetComponent<CharacterVision>();
    }

    void Update()
    {
        characterVision.CalculateVisionArea(grid.GetGridPosition(transform.position), character.visionRange, true);
    }
}
