using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject cmdpanel;
    [SerializeField] CommandInput commandInput;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (commandInput.isCommandInput == true) { return; }
            if (cmdpanel.activeSelf == false)
            {
                panel.SetActive(true);
            }
        }
    }
}
