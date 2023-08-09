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
    public float mouseRotationSpeed = 10f;

    private bool normalMovement;
    private bool difficultMovement;
    private bool invertedMovement;

    private bool isInMaze;
    private bool isInMathsLevel;
    private float mouseX;

    private GameObject enemySpawningPlane;
    private GameObject difficultMovementPlane;
    private Vector3 enemySpawningPlaneOffset;
    private Vector3 difficultMovementPlaneOffset;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        enemySpawningPlane = GameObject.FindGameObjectWithTag("EnemySpawningPlane");
        difficultMovementPlane = GameObject.FindGameObjectWithTag("DifficultMovementPlane");
        SetEnemySpawningPlaneOffset();
        SetDifficultMovementPlaneOffset();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += MovePlayerToEnemySpawningPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneFall += MovePlayerToDifficultMovementPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += RunDifficultMovementPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += RunEnemySpawningPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ActivateIsInMazeBool;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += DeactivateIsInMazeBool;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += ActivateIsInMathsLevel;
        GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += DeactivateIsInMathsLevel;
        //GameManager.instance.CollisionEvent.OnPla += ActivateIsInMathsLevel;



        //normalMovement = true; 
        ActivateNormalMovement();
        DeactivateIsInMathsLevel();
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
        if (!isInMathsLevel)
        {
            GetPlayerInputAxis();
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
    }

    private void SetPlayerMoveDirection()
    {
        if (!isInMaze)
        {
            moveDirection = new Vector3(xInput, 0, zInput).normalized;
        }
        else
        {
            Vector3 right = transform.right * xInput;
            Vector3 forward = transform.forward * zInput;

            moveDirection = (right + forward).normalized;
        }
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
        if (!isInMaze)
        { 
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, mouseX, 0) * Time.deltaTime * mouseRotationSpeed);
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }



    private void GetPlayerInputAxis()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
        
        mouseX = Input.GetAxis("Mouse X");
        
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

    private void SetDifficultMovementPlaneOffset()
    {
        difficultMovementPlaneOffset = (difficultMovementPlane.transform.position - new Vector3(0, 0, 15));
    }

    private void MovePlayerToEnemySpawningPlaneOffset()
    {
        transform.position = enemySpawningPlaneOffset;
    }

    private void MovePlayerToDifficultMovementPlaneOffset()
    {
        transform.position = difficultMovementPlaneOffset;
    }

    private void ActivateIsInMazeBool()
    {
        isInMaze = true;

        //move this to beginning of game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DeactivateIsInMazeBool()
    {
        isInMaze = false;
    }

    private void ActivateIsInMathsLevel()
    {
        isInMathsLevel = true;
    }

    private void DeactivateIsInMathsLevel()
    {
        isInMathsLevel = false;
    }

}


