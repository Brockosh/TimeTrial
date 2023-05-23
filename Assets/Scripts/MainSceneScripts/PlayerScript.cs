using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    Animator myAnimator;
    float xInput;
    float zInput;
    float xVelocity;
    float zVelocity;
    public float moveSpeed;
    private Vector3 moveDirection;
    public float jumpForce = 10f;
    public float rotationSpeed = 10f;
    private bool normalMovement;
    private bool difficultMovement;
    private bool invertedMovement;

    private GameObject enemySpawningPlane;
    private Vector3 enemySpawningPlaneOffset;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        enemySpawningPlane = GameObject.FindGameObjectWithTag("EnemySpawningPlane");
        SetEnemySpawningPlaneOffset();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += MovePlayerToEnemySpawningPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += RunDifficultMovementPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += RunEnemySpawningPlaneExitOperations;

        normalMovement = true; 
        //SetPlayerWalkForward();

        ////GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionSceneChanger += ShiftPlayerPositionForward;
        ////GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += ReloadScene;
    }


    private void FixedUpdate()
    {
        BasicPlayerMovement();
        ControlPlayerAnimations();
        //SetUpPlayerMovement();
        //DifficultPlayerMovement();
        //InvertedPlayerMovement();
    }

    private void BasicPlayerMovement()
    {
        GetPlayerInputAxis();
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");
        if (normalMovement)
        {
            SetPlayerMoveDirection();
        }
        else if (invertedMovement)
        {
            InvertPlayerMoveDirection();
        }
        else if (difficultMovement)
        {
            SetDifficultPlayerMoveDirection();
        }
        MovePlayer();
    }

    private void SetPlayerMoveDirection()
    {
        moveDirection = new Vector3(xInput, 0, zInput);
    }

    private void InvertPlayerMoveDirection()
    {
        moveDirection = new Vector3(-xInput, 0, -zInput);
    }


    private void SetDifficultPlayerMoveDirection()
    {
        float tempInput = xInput;
        xInput = zInput;
        zInput = tempInput;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            xInput = -xInput;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            zInput = -zInput;
        }

        moveDirection = new Vector3(xInput, 0, zInput);
    }

    //private void MovePlayer()
    //{
    //    transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    //}

    private void MovePlayer()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }



    private void GetPlayerInputAxis()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
    }

    private void ControlPlayerAnimations()
    {
        if (moveDirection != Vector3.zero)
        {
            myAnimator.SetBool("isWalking", true);
        }
        else
        {

            myAnimator.SetBool("isWalking", false);
        }
    }

    private void RunDifficultMovementPlaneEntranceOperations()
    {
        DeactivateNormalMovement();
        ActivateDifficultMovement();
    }

    private void RunDifficultMovementPlaneExitOperations()
    {
        DeactivateDifficultMovement();
        ActivateNormalMovement();
    }

    private void RunEnemySpawningPlaneEntranceOperations()
    {
        normalMovement = false;
        invertedMovement = true;
    }

    private void RunEnemySpawningPlaneExitOperations()
    {
        invertedMovement = false;
        normalMovement = true;
    }
    private void ActivateNormalMovement()
    {
        normalMovement = true;
    }

    private void DeactivateNormalMovement()
    {
        normalMovement = false;
    }

    private void ActivateDifficultMovement()
    {
        difficultMovement = true;
    }

    private void DeactivateDifficultMovement()
    {
        difficultMovement = false;
    }

    private void ShiftPlayerPositionForward()
    {
        transform.position += new Vector3(0, 10, 0);
    }

    private void ActivateInvertedMovement()
    {
        invertedMovement = true;    
    }

    private void SetEnemySpawningPlaneOffset()
    {
        enemySpawningPlaneOffset = (enemySpawningPlane.transform.position - new Vector3(0, 0, 15));
    }

    private void MovePlayerToEnemySpawningPlaneOffset()
    {
        transform.position = enemySpawningPlaneOffset;
    }
  

}


