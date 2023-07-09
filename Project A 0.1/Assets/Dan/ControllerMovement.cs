using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{

    CharacterController charCont;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 10f;
    public float gravity = 20f;
    public float jumpSpeed = 8f;
    private int jc = 0;//jump count
    public Animator anim;
    //public Rigidbody bullet;
    public float shootSpeed = 10f;
    public static int ammo = 10;
    //public GameObject reward;
    

    public float pushSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (charCont.isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            jc = 0;
            anim.SetBool("isJumping", false);

            moveDirection = transform.right * moveX + transform.forward * moveZ;
            moveDirection *= speed;

            anim.SetFloat("Speed", moveZ);

            

            
        }

        if (jc < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                jc++;
                anim.SetBool("isJumping", true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        moveDirection.y -= gravity * Time.deltaTime;
        charCont.Move(moveDirection * Time.deltaTime);
    }

        //Debug.Log(jc);

/*
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("shoot");
            if (ammo > 0)
            {
                ammo--;
                Rigidbody bulletClone;
                Vector3 startPos = transform.position;
                startPos.y += 1f;

                bulletClone = Instantiate(bullet, startPos + transform.forward, transform.rotation);
                bulletClone.velocity = transform.forward * shootSpeed;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo < 10)
            {
                ammo = 10;
            }
        }

        if (Move.kills == 5)
        {
            //Debug.Log("You Win!");

                GameObject rewardClone;
                Vector3 rewardPos = transform.position;
                rewardPos.y += 1f;
                rewardPos.z += 2f;

                rewardClone = Instantiate(reward, rewardPos, transform.rotation);

                Move.kills = 0;
        }

        //Debug.Log(ammo);
    }
    */

    void playerShoot()
    {

    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
        {
            return;
        }


        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushSpeed;
    }



}
