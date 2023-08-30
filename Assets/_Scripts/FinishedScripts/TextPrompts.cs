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

    // Makes the text pulse in size
    public void Pulse()
    {
        textComponent.rectTransform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);     
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


    // Attach methods to GameManager's collision events
    private void AttachDelegates()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += findTheRightDoor.ActivateAndAnimate;
        GameManager.instance.CollisionEvent.OnPlayerCollisionCorrectDoor += findTheRightDoor.Deactivate;


        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += mazeColourIndicateYourProgress.Activate;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeEntrance += mazeColourIndicateYourProgress.Pulse;
        GameManager.instance.CollisionEvent.OnPlayerCollisionMazeExit += mazeColourIndicateYourProgress.Deactivate;


        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateEnemyTexts;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DeactivateEnemyTexts;

        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlane += ActivateMovementTexts;
        GameManager.instance.CollisionEvent.OnPlayerCollisionDifficultMovementPlaneExit += DeactivateMovementTexts;

        GameManager.instance.CollisionEvent.OnPlayerCollisionFinishLine += finished.ActivateAndAnimate;
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

    //Activates texts for enemy spawning plane
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

    //Activates text for weird movement obstacle
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