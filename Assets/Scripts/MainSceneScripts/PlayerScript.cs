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

        normalMovement= true;
        ////GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionSceneChanger += ShiftPlayerPositionForward;
        ////GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += ReloadScene;
    }


    private void FixedUpdate()
    {
        SetUpPlayerMovement();
        DifficultPlayerMovement();
        InvertedPlayerMovement();
    }


    private void GetPlayerInputAxis()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void SetPlayerVelocity()
    {
        rb.velocity = new Vector3(xVelocity, rb.velocity.y, 0) + (transform.forward * zVelocity);
    }
    

    private void AssignXAndZVelocities()
    {
        //xVelocity = xInput * moveSpeed;
        Debug.Log(xInput);
        transform.Rotate(transform.up * moveSpeed * xInput);
        zVelocity = zInput * moveSpeed;
    }

    private void DifficultPlayerMovement()
    {
        if (difficultMovement) 
            { 
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector3.back * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = Vector3.forward * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = Vector3.right * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = Vector3.left * moveSpeed;
            }
            else { rb.velocity = Vector3.zero; }
        }
    }

    private void InvertedPlayerMovement()
    {
        if (invertedMovement)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector3.back * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = Vector3.right * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = Vector3.forward * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = Vector3.left * moveSpeed;
            }
            else { rb.velocity = Vector3.zero; }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DifficultMovementPlane"))
        {
            Invoke("DeactivateNormalMovement", .25f);
            Invoke("ActivateDifficultMovement", .25f);;
        }
        else if (collision.gameObject.CompareTag("EnemySpawningPlane"))
        {
            Invoke("DeactivateNormalMovement", .25f);
            Invoke("ActivateInvertedMovement", .25f); ;
        }
    }

  

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DifficultMovementPlane"))
        {
            difficultMovement = false;
            ActivateNormalMovement();
        }
        else if (collision.gameObject.CompareTag("EnemySpawningPlane"))
        {
            invertedMovement = false;
            ActivateNormalMovement();
        }
    }

    private void SetUpPlayerMovement()
    {
        if (normalMovement)
        {
            GetPlayerInputAxis();
            AssignXAndZVelocities();
            SetPlayerVelocity();
        }
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


