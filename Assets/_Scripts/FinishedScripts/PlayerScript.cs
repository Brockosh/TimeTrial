using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    Animator myAnimator;
    float xInput;
    float zInput;


    [SerializeField] private GameObject rightStickHolder;
    [SerializeField] private GameObject leftStickHolder;
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
        SetUpForInput();
        RunAssignments();
        ActivateNormalMovement();
        if (Application.platform == RuntimePlatform.Android)
        {
            mouseRotationSpeed = 250;
        }
    }

    private void FixedUpdate()
    {
        BasicPlayerMovement();
        ControlPlayerAnimations();
        if (Application.platform == RuntimePlatform.Android)
        {
            rightStickHolder.gameObject.SetActive(isInMaze);
        }
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
        if (Application.platform == RuntimePlatform.Android)
        {
            xInput = leftStick.xAxis;
            zInput = leftStick.yAxis;


            mouseX = rightStick.xAxis;
        }
        else
        {
            xInput = Input.GetAxisRaw("Horizontal");
            zInput = Input.GetAxisRaw("Vertical");

            mouseX = Input.GetAxis("Mouse X");
        }
    }

    private void SetUpForInput()
    {
        RuntimePlatform platform = Application.platform;
        if (platform == RuntimePlatform.Android)
        {
            rightStickHolder.gameObject.SetActive(false);
        }
        else
        {
            rightStickHolder.gameObject.SetActive(false);
            leftStickHolder.gameObject.SetActive(false);
        }
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


