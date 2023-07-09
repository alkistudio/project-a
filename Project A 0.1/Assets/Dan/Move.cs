using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    float speed = 5f;
    bool e1left = false;
    bool e1right = true;
    bool e2left = false;
    bool e2right = true;
    bool e3left = false;
    bool e3right = true;
    bool e4left = false;
    bool e4right = true;
    bool e5left = false;
    bool e5right = true;


    public bool enemy1 = false;
    public bool enemy2 = false;
    public bool enemy3 = false;
    public bool enemy4 = false;
    public bool enemy5 = false;

    public static int kills = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (enemy1)
        {
            transform.position = new Vector3(-31.5f, 1, 0);
        }
        if (enemy2)
        {
            transform.position = new Vector3(-16, 1, -1);
        }
        if (enemy3)
        {
            transform.position = new Vector3(8.5f, 1, -.5f);
        }
        if (enemy4)
        {
            transform.position = new Vector3(-6, 1, 15);
        }
        if (enemy5)
        {
            transform.position = new Vector3(-16, 1, 32);
        }
    }
        
        
    

    // Update is called once per frame
    void Update()
    {

        if (enemy1)
        {
            if (transform.position.z < 0 && e1left)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.z > 0 && e1left)
            {
                e1left = false;
                e1right = true;
            }
        }

        if (transform.position.z < 1 && e1right)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.z < -27 && e1right)
            {
                e1left = true;
                e1right = false;
            }
        }
        }

        if (enemy2)
        {
            if (transform.position.x > -16 && e2left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x < -16 && e2left)
            {
                e2left = false;
                e2right = true;
            }
        }

        if (transform.position.x < 1 && e2right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x > 1 && e2right)
            {
                e2left = true;
                e2right = false;
            }
        }
        }

        if (enemy3)
        {
            if (transform.position.x > 8.5 && e3left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x < 8.5 && e3left)
            {
                e3left = false;
                e3right = true;
            }
        }

        if (transform.position.x < 17 && e3right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x > 17 && e3right)
            {
                e3left = true;
                e3right = false;
            }
        }
        }

        if (enemy4)
        {
            if (transform.position.x > -6 && e4left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x < -6 && e4left)
            {
                e4left = false;
                e4right = true;
            }
        }

        if (transform.position.x < 26 && e4right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x > 26 && e4right)
            {
                e4left = true;
                e4right = false;
            }
        }
        }

        if (enemy5)
        {
            if (transform.position.x > -16 && e5left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x < -16 && e5left)
            {
                e5left = false;
                e5right = true;
            }
        }

        if (transform.position.x < 10 && e5right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //Debug.Log(transform.position.x);
            if (transform.position.x > 10 && e5right)
            {
                e5left = true;
                e5right = false;
            }
        }
        }
        
        

        

    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "Projectile(Clone)")
        {
            Destroy(gameObject);
            kills++;
            Destroy(other.gameObject);
        }
    }


}
