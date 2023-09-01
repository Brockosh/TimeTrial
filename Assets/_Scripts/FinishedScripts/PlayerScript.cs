using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    Animator myAnimator;
    float xInput;
    float zInput;

    [SerializeField] private Thumbstick rightStick;
    [SerializeField] private Thumbstick leftStick;


    bool playerFrozen;
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
        RunSetup();
        RunAssignments();
        ActivateNormalMovement();
    }

    private void FixedUpdate()
    {
        BasicPlayerMovement();
        ControlPlayerAnimations();
    }

    private void BasicPlayerMovement()
    {
        if (!isInMathsLevel && !playerFrozen)
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

        moveDirection = new Vector3(xInput, 0, zInput).normalized;
    }

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
#if UNITY_IOS

        xInput = rightStick.xAxis;
        zInput = rightStick.yAxis;
        
        if (xInput > 0)
        {
            xInput = 1;
        }
        if (xInput < 0)
        {
            xInput = -1;
        }

        if (zInput > 0)
        {
            zInput = 1;
        }
        if (zInput < 0)
        {
            zInput = -1;
        }

        mouseX = leftStick.xAxis;



#else 
        xInput = rightStick.xAxis;
        zInput = rightStick.yAxis;

        //if (xInput > 0)
        //{
        //    xInput = 1;
        //}
        //if (xInput < 0)
        //{
        //    xInput = -1;
        //}

        //if (zInput > 0)
        //{
        //    zInput = 1;
        //}
        //if (zInput < 0)
        //{
        //    zInput = -1;
        //}

        mouseX = leftStick.xAxis * 0.3f;
  

        //xInput = Input.GetAxisRaw("Horizontal");
        //zInput = Input.GetAxisRaw("Vertical");
        
        //mouseX = Input.GetAxis("Mouse X");
#endif
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
    }

    private void DeactivateIsInMazeBool()
    {
        isInMaze = false;
    }

    private void FreezePlayer()
    {
        moveSpeed = 0;
        rotationSpeed = 0;
        playerFrozen = true;
    }

    private void UnFreezePlayer()
    {
        moveSpeed = 5;
        rotationSpeed = 10;
        playerFrozen = false;
    }

    private  void RunSetup()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        enemySpawningPlane = GameObject.FindGameObjectWithTag("EnemySpawningPlane");
        difficultMovementPlane = GameObject.FindGameObjectWithTag("DifficultMovementPlane");
        SetEnemySpawningPlaneOffset();
        SetDifficultMovementPlaneOffset();
    }

    private void RunAssignments()
    {
        GameManager.instance.gameEvents.OnPlayerHasEnteredMainScene += FreezePlayer;
        GameManager.instance.gameEvents.OnPreGameTimerFinished += UnFreezePlayer;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemy += MovePlayerToEnemySpawningPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneFall += MovePlayerToDifficultMovementPlaneOffset;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += RunDifficultMovementPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneEntranceOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += RunEnemySpawningPlaneExitOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += ActivateIsInMazeBool;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += DeactivateIsInMazeBool;
    }
}


