using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOutOfVision : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    [SerializeField] GameObject gameManager;

    CharacterVision characterVision;

    void Awake()
    {
        characterVision = gameManager.GetComponent<CharacterVision>();   
    }

    void Update()
    {
        //Debug.Log(characterVision.visiblePosition);
        //Debug.Log(targetGrid.GetGridPosition(transform.position));
        /*if (characterVision.visiblePosition.Contains((targetGrid.GetGridPosition(transform.position))) == false)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }*/

        switch (characterVision.visiblePosition.Contains((targetGrid.GetGridPosition(transform.position))))
        {
            case false:
                
                GetComponent<MeshRenderer>().enabled = false;
                break;
            
            case true:
                
                GetComponent<MeshRenderer>().enabled = true;
                break;
        }
    }
}
