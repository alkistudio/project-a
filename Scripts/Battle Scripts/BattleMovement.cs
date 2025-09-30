using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActionMode
{
    Default,
    Move,
    Dash,
    Feint,
    Slash
}

public enum BattleCommandType
{
    Move,
    Dash,
    Feint,
    Slash
}

public class BattleCommand
{
    public BattleCommandType battleCommandType;
    public string keyPressed;

    public BattleCommand (BattleCommandType battleCommandType, string keyPressed)
    {
        this.battleCommandType = battleCommandType;
        this.keyPressed = keyPressed;
    }
}
public class BattleMovement : MonoBehaviour
{

    public ActionMode actionMode;
    public BattleCommand currentBattleCommand;
    [SerializeField] GameObject enemy;

    public float speed = 10f;
    public float dynamicSpeed;

    private Vector3 moveTarget;
    private float distanceToTarget;
    private Vector3 enemyPosition;
    public float radialMoveDistance = 1f;
    public float angularMoveDistance = 20f;
    private Animator animator;
    private EnemyBehavior enemyBehavior;
    private void Start()
    {
        actionMode = ActionMode.Default;
        moveTarget = transform.position;
        enemyPosition = enemy.transform.position;
        distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
        dynamicSpeed = speed;
        animator = GetComponentInChildren<Animator>();
        enemyBehavior = enemy.GetComponentInChildren<EnemyBehavior>();
        Debug.Log(enemyBehavior);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, dynamicSpeed * Time.deltaTime);
        if (Vector3.Magnitude(transform.position - moveTarget) < 0.005)
        {
            dynamicSpeed = speed;
        }
        
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actionMode = ActionMode.Move;

            if (Input.GetMouseButton(1))
            {
                actionMode = ActionMode.Dash;
            }
        }

        else if (Input.GetMouseButton(0))
        {
            actionMode = ActionMode.Slash;
        }
        
        else
        {
            actionMode = ActionMode.Default;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (actionMode)
            {
                case ActionMode.Default:
                    break;

                case ActionMode.Move:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    if (distanceToTarget < 3) { break; }
                    CalculateNewRadialPosition(radialMoveDistance);
                    break;

                case ActionMode.Dash:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    dynamicSpeed *= 20;
                    CalculateNewRadialPosition(distanceToTarget - 3);
                    break;

                case ActionMode.Slash:
                    animator.SetTrigger("Slash90");
                    enemyBehavior.ExecuteParry();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (actionMode)
            {
                case ActionMode.Default:
                    break;
                
                case ActionMode.Move:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    CalculateNewRadialPosition(-radialMoveDistance);
                    break;

                case ActionMode.Slash:
                    animator.SetTrigger("Thrust");
                    enemyBehavior.ExecuteParry();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (actionMode)
            {
                case ActionMode.Default:
                    break;
                
                case ActionMode.Move:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    CalculateNewAngularPostion(angularMoveDistance / (distanceToTarget/2));
                    break;
                
                case ActionMode.Dash:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    dynamicSpeed *= 20;
                    CalculateNewAngularPostion(45);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            switch (actionMode)
            {
                case ActionMode.Default:
                    break;
                
                case ActionMode.Move:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    CalculateNewAngularPostion(-angularMoveDistance / (distanceToTarget/2));
                    break;
                
                case ActionMode.Dash:
                    distanceToTarget = Vector3.Distance(transform.position, enemyPosition);
                    dynamicSpeed *= 20;
                    CalculateNewAngularPostion(-45);
                    break;
            }
        }
    }

    private void CalculateNewRadialPosition(float moveDistance)
    {
        float scaleFactor = (distanceToTarget - moveDistance) / distanceToTarget;
        moveTarget.x = moveTarget.x * scaleFactor;
        moveTarget.z = moveTarget.z * scaleFactor;

    }

    private void CalculateNewAngularPostion(float angularMoveDistance)
    {
        Vector2 vectorPos = new Vector2(transform.position.x, transform.position.z);
        
        float currentAngle = Vector2.SignedAngle(vectorPos, Vector2.right);
        
        if (currentAngle < 0)
        {
            currentAngle = 360 + currentAngle;
        }
        
        float newAngle = angularMoveDistance + currentAngle;
        
        moveTarget.x = distanceToTarget * Mathf.Cos(newAngle * Mathf.Deg2Rad);
        moveTarget.z = -1 * distanceToTarget * Mathf.Sin(newAngle * Mathf.Deg2Rad);

        /*Debug.Log(vectorPos);
        Debug.Log(currentAngle);
        Debug.Log(newAngle);
        Debug.Log(Mathf.Sin(newAngle * Mathf.Deg2Rad));
        Debug.Log(Mathf.Cos(newAngle * Mathf.Deg2Rad));
        */
    }
    
}
