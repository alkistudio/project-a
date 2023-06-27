using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stats : MonoBehaviour
{
    private bool displayMenu;

    //Stats
    public float statStrength;
    public float statSpeed;
    public float statStamina;
    public float statWillpower;
    public float statNeuroticism;

    public float statStoredIchor;

    public List<string> Abilities = new List<string> { "Ability1", "Ability2", "Ability3", "Ability4" };
    
    void Start()
    {
        displayMenu = false;
        
        statStrength = 20;
        statSpeed = 20;
        statStamina = 20;
        statWillpower = 20;
        statNeuroticism = 20;

        statStoredIchor = 700;

    }

    void OnMouseDown()
    {
        displayMenu = !displayMenu;
    }

    void Update()
    {
        //if (displayMenu = True && )
    }

}
