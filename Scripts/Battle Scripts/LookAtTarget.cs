using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    public bool flipDirection;
    private Vector3 lookDirection;
    public float repointSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 lookDirection = -transform.position + targetPos;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, repointSpeed * Time.deltaTime);
        if (flipDirection == true) {transform.Rotate(0,180,0);}
    }
}
