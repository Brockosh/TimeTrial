//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using DG.Tweening;

//public class TextPrompts : MonoBehaviour
//{

//    public TextMeshProUGUI findTheRightDoor;
//    public TextMeshProUGUI invertedMovement;
//    public TextMeshProUGUI dodgeTheGhosts;
//    public TextMeshProUGUI weirdMovement;
//    public TextMeshProUGUI moveAroundTheBrickWalls;
//    public TextMeshProUGUI finished;
//    public TextMeshProUGUI answerFasterThanRobot;
//    private bool hasPlayerHitDifficultMovementPlane;
//    private bool hasPlayerHitEnemySpawningPlane;
//    // Start is called before the first frame update
//    void Start()
//    {
//        findTheRightDoor.gameObject.SetActive(false);
//        invertedMovement.gameObject.SetActive(false);
//        dodgeTheGhosts.gameObject.SetActive(false);
//        weirdMovement.gameObject.SetActive(false);
//        moveAroundTheBrickWalls.gameObject.SetActive(false);
//        finished.gameObject.SetActive(false);
//        answerFasterThanRobot.gameObject.SetActive(false);  
//        hasPlayerHitDifficultMovementPlane = false;
//        hasPlayerHitEnemySpawningPlane = false;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += ActivateFindTheRightDoorText;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionCorrectDoor += DeativateFindTheRightDoorText;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneTextOperations;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateEnemySpawningBool;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DeactivateInvertedMovementAndGhostDodgeText;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += RunDifficultMovementTextOperations;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += ActivateDifficultMovementBool;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += DeactivateWeirdMovementAndBrickWallText;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += ActivateFinishedText;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += ActivateAnswerFasterThanRobotText;
//        GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += DeactivateAnswerFasterThanRobotText;

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void ActivateFindTheRightDoorText()
//    {
//        findTheRightDoor.gameObject.SetActive(true);
//    }

//    private void DeativateFindTheRightDoorText()
//    {
//        findTheRightDoor.gameObject.SetActive(false);
//    }
//    private void ActivateInvertedMovementAndGhostDodgeText()
//    {
//        invertedMovement.gameObject.SetActive(true);
//        dodgeTheGhosts.gameObject.SetActive(true);
//    }

//    private void DeactivateInvertedMovementAndGhostDodgeText()
//    {
//        invertedMovement.gameObject.SetActive(false);
//        dodgeTheGhosts.gameObject.SetActive(false);
//    }

//    private void RunEnemySpawningPlaneTextOperations()
//    {
//        if (!hasPlayerHitEnemySpawningPlane)
//        {
//            ActivateInvertedMovementAndGhostDodgeText();
//            Invoke("DeactivateInvertedMovementAndGhostDodgeText", 3f);
//        }
//    }

//    private void ActivateWeirdMovementAndBrickWallText()
//    {
//        weirdMovement.gameObject.SetActive(true);
//        moveAroundTheBrickWalls.gameObject.SetActive(true);
//    }

//    private void DeactivateWeirdMovementAndBrickWallText()
//    {
//        weirdMovement.gameObject.SetActive(false);
//        moveAroundTheBrickWalls.gameObject.SetActive(false);
//    }

//    private void RunDifficultMovementTextOperations()
//    {
//        if (!hasPlayerHitDifficultMovementPlane)
//        {
//            ActivateWeirdMovementAndBrickWallText();
//            Invoke("DeactivateWeirdMovementAndBrickWallText", 3f);
//        }
//    }

//    private void ActivateDifficultMovementBool()
//    {
//        hasPlayerHitDifficultMovementPlane = true;
//    }

//    private void ActivateEnemySpawningBool()
//    {
//        hasPlayerHitEnemySpawningPlane = true;
//    }

//    private void ActivateFinishedText()
//    {
//        finished.gameObject.SetActive(true);
//        finished.rectTransform.DOScale(1.5f, 0.5f).OnComplete(() =>
//        {
//            finished.rectTransform.DOScale(1f, 0.5f);
//        });
//    }

//    private void ActivateAnswerFasterThanRobotText()
//    {
//        answerFasterThanRobot.gameObject.SetActive(true);
//    }

//    private void DeactivateAnswerFasterThanRobotText()
//    {
//        answerFasterThanRobot.gameObject.SetActive(false);
//    }


//}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class TextPrompt
{
    public TextMeshProUGUI textComponent;
    public bool hasActivated = false;

    public void Activate()
    {
        if (!hasActivated)
        {
            textComponent.gameObject.SetActive(true);
            hasActivated = true;
        }
    }

    public void Deactivate()
    {
        textComponent.gameObject.SetActive(false);
    }

    public void Animate()
    {
        textComponent.rectTransform.DOScale(1.5f, 0.5f).OnComplete(() =>
        {
            textComponent.rectTransform.DOScale(1f, 0.5f);
        });
    }

    public void ActivateAndAnimate()
    {
        Activate();
        Animate();
    }
}

public class TextPrompts : MonoBehaviour
{
    public TextPrompt findTheRightDoor;
    public TextPrompt invertedMovement;
    public TextPrompt dodgeTheGhosts;
    public TextPrompt weirdMovement;
    public TextPrompt moveAroundTheBrickWalls;
    public TextPrompt mazeColourIndicateYourProgress;
    public TextPrompt finished;
    public TextPrompt answerFasterThanRobot;

    void Start()
    {
        AttachDelegates();
        InitializeTextPrompts();
    }

    private void AttachDelegates()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += findTheRightDoor.ActivateAndAnimate;
        GameManager.instance.CollisionEvent.OnPlayerCollisionCorrectDoor += findTheRightDoor.Deactivate;


        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += mazeColourIndicateYourProgress.ActivateAndAnimate;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += mazeColourIndicateYourProgress.Deactivate;



        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateEnemyTexts;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DeactivateEnemyTexts;

        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += ActivateMovementTexts;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += DeactivateMovementTexts;

        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += finished.ActivateAndAnimate;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += answerFasterThanRobot.ActivateAndAnimate;
        GameManager.instance.mathEvents.OnPlayerFinishedMathsScene += answerFasterThanRobot.Deactivate;
    }

    private void InitializeTextPrompts()
    {
        findTheRightDoor.Deactivate();
        invertedMovement.Deactivate();
        dodgeTheGhosts.Deactivate();
        weirdMovement.Deactivate();
        moveAroundTheBrickWalls.Deactivate();
        finished.Deactivate();
        answerFasterThanRobot.Deactivate();
        mazeColourIndicateYourProgress.Deactivate();
    }

    private void ActivateEnemyTexts()
    {
        if (!invertedMovement.hasActivated)
        {
            invertedMovement.ActivateAndAnimate();
            dodgeTheGhosts.ActivateAndAnimate();

            DOVirtual.DelayedCall(3f, DeactivateEnemyTexts);
        }
    }

    private void DeactivateEnemyTexts()
    {
        invertedMovement.Deactivate();
        dodgeTheGhosts.Deactivate();
    }

    private void ActivateMovementTexts()
    {
        if (!weirdMovement.hasActivated)
        {
            weirdMovement.ActivateAndAnimate();
            moveAroundTheBrickWalls.ActivateAndAnimate();

            DOVirtual.DelayedCall(3f, DeactivateMovementTexts);
        }
    }

    private void DeactivateMovementTexts()
    {
        weirdMovement.Deactivate();
        moveAroundTheBrickWalls.Deactivate();
    }
}