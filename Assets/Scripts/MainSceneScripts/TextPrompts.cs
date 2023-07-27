using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPrompts : MonoBehaviour
{

    public TextMeshProUGUI findTheRightDoor;
    public TextMeshProUGUI invertedMovement;
    public TextMeshProUGUI dodgeTheGhosts;
    public TextMeshProUGUI weirdMovement;
    public TextMeshProUGUI moveAroundTheBrickWalls;
    public TextMeshProUGUI finished;
    public TextMeshProUGUI answerFasterThanRobot;
    private bool hasPlayerHitDifficultMovementPlane;
    private bool hasPlayerHitEnemySpawningPlane;
    // Start is called before the first frame update
    void Start()
    {
        findTheRightDoor.gameObject.SetActive(false);
        invertedMovement.gameObject.SetActive(false);
        dodgeTheGhosts.gameObject.SetActive(false);
        weirdMovement.gameObject.SetActive(false);
        moveAroundTheBrickWalls.gameObject.SetActive(false);
        finished.gameObject.SetActive(false);
        answerFasterThanRobot.gameObject.SetActive(false);  
        hasPlayerHitDifficultMovementPlane = false;
        hasPlayerHitEnemySpawningPlane = false;
        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += ActivateFindTheRightDoorText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionCorrectDoor += DeativateFindTheRightDoorText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneTextOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateEnemySpawningBool;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DeactivateInvertedMovementAndGhostDodgeText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementTextOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += ActivateDifficultMovementBool;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += DeactivateWeirdMovementAndBrickWallText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += ActivateFinishedText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += ActivateAnswerFasterThanRobotText;
        GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += DeactivateAnswerFasterThanRobotText;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateFindTheRightDoorText()
    {
        findTheRightDoor.gameObject.SetActive(true);
    }
    
    private void DeativateFindTheRightDoorText()
    {
        findTheRightDoor.gameObject.SetActive(false);
    }
    private void ActivateInvertedMovementAndGhostDodgeText()
    {
        invertedMovement.gameObject.SetActive(true);
        dodgeTheGhosts.gameObject.SetActive(true);
    }

    private void DeactivateInvertedMovementAndGhostDodgeText()
    {
        invertedMovement.gameObject.SetActive(false);
        dodgeTheGhosts.gameObject.SetActive(false);
    }

    private void RunEnemySpawningPlaneTextOperations()
    {
        if (!hasPlayerHitEnemySpawningPlane)
        {
            ActivateInvertedMovementAndGhostDodgeText();
            Invoke("DeactivateInvertedMovementAndGhostDodgeText", 3f);
        }
    }

    private void ActivateWeirdMovementAndBrickWallText()
    {
        weirdMovement.gameObject.SetActive(true);
        moveAroundTheBrickWalls.gameObject.SetActive(true);
    }

    private void DeactivateWeirdMovementAndBrickWallText()
    {
        weirdMovement.gameObject.SetActive(false);
        moveAroundTheBrickWalls.gameObject.SetActive(false);
    }

    private void RunDifficultMovementTextOperations()
    {
        if (!hasPlayerHitDifficultMovementPlane)
        {
            ActivateWeirdMovementAndBrickWallText();
            Invoke("DeactivateWeirdMovementAndBrickWallText", 3f);
        }
    }

    private void ActivateDifficultMovementBool()
    {
        hasPlayerHitDifficultMovementPlane = true;
    }

    private void ActivateEnemySpawningBool()
    {
        hasPlayerHitEnemySpawningPlane = true;
    }

    private void ActivateFinishedText()
    {
        finished.gameObject.SetActive(true);
    }

    private void ActivateAnswerFasterThanRobotText()
    {
        answerFasterThanRobot.gameObject.SetActive(true);
    }

    private void DeactivateAnswerFasterThanRobotText()
    {
        answerFasterThanRobot.gameObject.SetActive(false);
    }


}

