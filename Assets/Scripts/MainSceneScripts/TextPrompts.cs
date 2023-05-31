using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPrompts : MonoBehaviour
{

    public TextMeshProUGUI findTheRightDoor;
    public TextMeshProUGUI invertedMovement;
    public TextMeshProUGUI dodgeTheGhosts;
    // Start is called before the first frame update
    void Start()
    {
        findTheRightDoor.gameObject.SetActive(false);
        invertedMovement.gameObject.SetActive(false);
        dodgeTheGhosts.gameObject.SetActive(false);
        GameManager.instance.CollisionEvent.OnPlayerCollisionStartLine += ActivateFindTheRightDoorText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionCorrectDoor += DeativateFindTheRightDoorText;
        //GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += ActivateInvertedMovementAndGhostDodgeText;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += RunEnemySpawningPlaneTextOperations;
        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += DeactivateInvertedMovementAndGhostDodgeText;
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
        ActivateInvertedMovementAndGhostDodgeText();
        Invoke("DeactivateInvertedMovementAndGhostDodgeText", 3f);
    }

}
