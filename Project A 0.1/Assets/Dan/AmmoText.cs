using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    Text ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ControllerMovement.ammo);
        
        ammo.text = "Ammo: " + ControllerMovement.ammo;
    }


    public void ammoUpdate()
    {
        
    }
}
