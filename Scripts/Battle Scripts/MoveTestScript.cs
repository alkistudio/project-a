using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveTestScript : MonoBehaviour
{

    private float speed;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target = new Vector3(transform.position.x + 5, transform.position.y,transform.position.z);   
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
