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
    float xInput;
    float zInput;
    float xVelocity;
    float zVelocity;
    public float moveSpeed;
    private Vector3 moveDirection;
    public float jumpForce = 10f;
    private bool normalMovement;
    private bool difficultMovement;
    private bool invertedMovement;

    private GameObject enemySpawningPlane;
    private Vector3 enemySpawningPlaneOffset;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemySpawningPlane = GameObject.FindGameObjectWithTag("EnemySpawningPlane");
        SetEnemySpawningPlaneOffset();
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += MovePlayerToEnemySpawningPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += RunDifficultMovementPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += RunEnemySpawningPlaneExitOperations;

        normalMovement = true; ; 

        ////GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionSceneChanger += ShiftPlayerPositionForward;
        ////GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += ReloadScene;
    }


    private void FixedUpdate()
    {
        BasicPlayerMovement();
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
        //Vector3 moveDirection = new Vector3(xInput, 0, zInput);
        MovePlayer();
       // transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void SetPlayerMoveDirection()
    {
        moveDirection = new Vector3(xInput, 0, zInput);
    }

    private void InvertPlayerMoveDirection()
    {
        moveDirection = new Vector3(-xInput, 0, -zInput);
    }

    //private void SetDifficultPlayerMoveDirection()
    //{


    //    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
    //    {
    //        xInput = -xInput;
    //    }

    //    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    //    {
    //        zInput = -zInput;
    //    }

    //    moveDirection = new Vector3(xInput, 0, zInput);
    //}

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

    private void MovePlayer()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    }

    private void GetPlayerInputAxis()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
    }

    //private void SetPlayerVelocity()
    //{
    //    rb.velocity = new Vector3(xVelocity, rb.velocity.y, 0) + (transform.forward * zVelocity);
    //}
    

    //private void AssignXAndZVelocities()
    //{
    //    //xVelocity = xInput * moveSpeed;
    //    Debug.Log(xInput);
    //    transform.Rotate(transform.up * moveSpeed * xInput);
    //    zVelocity = zInput * moveSpeed;
    //}

    //private void DifficultPlayerMovement()
    //{
    //    if (difficultMovement) 
    //        { 
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            rb.velocity = Vector3.back * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.A))
    //        {
    //            rb.velocity = Vector3.forward * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.S))
    //        {
    //            rb.velocity = Vector3.right * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.D))
    //        {
    //            rb.velocity = Vector3.left * moveSpeed;
    //        }
    //        else { rb.velocity = Vector3.zero; }
    //    }
    //}

    //private void InvertedPlayerMovement()
    //{
    //    if (invertedMovement)
    //    {
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            rb.velocity = Vector3.back * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.A))
    //        {
    //            rb.velocity = Vector3.right * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.S))
    //        {
    //            rb.velocity = Vector3.forward * moveSpeed;
    //        }
    //        else if (Input.GetKey(KeyCode.D))
    //        {
    //            rb.velocity = Vector3.left * moveSpeed;
    //        }
    //        else { rb.velocity = Vector3.zero; }
    //    }
    //}



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DifficultMovementPlane"))
    //    {
    //        Invoke("DeactivateNormalMovement", .25f);
    //        Invoke("ActivateDifficultMovement", .25f);;
    //    }
    //    else if (collision.gameObject.CompareTag("EnemySpawningPlane"))
    //    {
    //        Invoke("DeactivateNormalMovement", .25f);
    //        Invoke("ActivateInvertedMovement", .25f); ;
    //    }
    //}

  

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DifficultMovementPlane"))
    //    {
    //        difficultMovement = false;
    //        ActivateNormalMovement();
    //    }
    //    else if (collision.gameObject.CompareTag("EnemySpawningPlane"))
    //    {
    //        invertedMovement = false;
    //        ActivateNormalMovement();
    //    }
    //}

    //private void SetUpPlayerMovement()
    //{
    //    if (normalMovement)
    //    {
    //        GetPlayerInputAxis();
    //        AssignXAndZVelocities();
    //        SetPlayerVelocity();
    //    }
    //}

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


