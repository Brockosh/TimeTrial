using System.Collections;
using UnityEngine;

public class MazeBlock : MonoBehaviour
{
    public Material myMaterial; 
    public enum ColorState { White, Red, Green, Orange, Yellow } 
    ColorState currentState = ColorState.White; 
    ColorState lastState = ColorState.Red; 

    // Start function initializes some properties
    private void Start()
    {
        RunAssignments(); 
        myMaterial.color = Color.white; 
    }

    void Update()
    {
        UpdateState(); 
    }

    // Functions to set current state to a specific color
    public void ChangeColourToRed()
    {
        currentState = ColorState.Red;
    }

    public void ChangeColourToOrange()
    {
        currentState = ColorState.Orange;
    }

    public void ChangeColourToYellow()
    {
        currentState = ColorState.Yellow;
    }

    public void ChangeColourToGreen()
    {
        currentState = ColorState.Green;
    }

    // Coroutine to change colors smoothly while in a particular state
    public IEnumerator ChangeColors(Color a, Color b, ColorState c)
    {
        while (currentState == c)
        {
            myMaterial.color = Color.Lerp(a, b, (Mathf.Sin(Time.timeSinceLevelLoad) + 1) / 2);
            yield return null;
        }
    }

    // Update the block's state if it has changed
    public void UpdateState()
    {
        if (lastState != currentState)
        {
            switch (currentState)
            {
                case ColorState.Red:
                    StartCoroutine(ChangeColors(Color.red, new Color(0.3f, 0, 0), currentState));
                    break;
                case ColorState.Green:
                    StartCoroutine(ChangeColors(new Color(0.7f, 1.0f, 0.7f), new Color(0.3f, 0.5f, 0.3f), currentState));
                    break;
                case ColorState.Orange:
                    StartCoroutine(ChangeColors(new Color(1.0f, 0.6f, 0.2f), new Color(1.0f, 0.8f, 0.0f), currentState));
                    break;
                case ColorState.Yellow:
                    StartCoroutine(ChangeColors(new Color(1.0f, 1.0f, 0.7f), new Color(0.5f, 0.5f, 0.3f), currentState));
                    break;
                default:
                    break;
            }
            lastState = currentState;
        }
    }

    // Subscribe to GameManager events to change block state when events occur
    private void RunAssignments()
    {
        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionRedZone += ChangeColourToRed;
        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionOrangeZone += ChangeColourToOrange;
        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionYellowZone += ChangeColourToYellow;
        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionGreenZone += ChangeColourToGreen;
    }
}


//using System.Collections;
//using UnityEngine;

//public class MazeBlock : MonoBehaviour
//{
//    public Material myMaterial;
//    public enum ColorState { White, Red, Green, Orange, Yellow }
//    ColorState currentState = ColorState.White;
//    ColorState lastState = ColorState.Red;

//    private void Start()
//    {
//        RunAssignments();
//        myMaterial.color = Color.white;
//    }

//    void Update()
//    {
//        UpdateState();
//    }

//    public void ChangeColourToRed()
//    {
//        currentState = ColorState.Red;
//    }

//    public void ChangeColourToOrange()
//    {
//        currentState = ColorState.Orange;
//    }

//    public void ChangeColourToYellow()
//    {
//        currentState = ColorState.Yellow;
//    }

//    public void ChangeColourToGreen()
//    {
//        currentState = ColorState.Green;
//    }

//    public IEnumerator ChangeColors(Color a, Color b, ColorState c)
//    {
//        while (currentState == c)
//        {
//            myMaterial.color = Color.Lerp(a, b, (Mathf.Sin(Time.timeSinceLevelLoad) + 1) / 2);
//            yield return null;
//        }
//    }

//    public void UpdateState()
//    {
//        if (lastState != currentState)
//        {
//            switch (currentState)
//            {
//                case ColorState.Red:
//                    {
//                        StartCoroutine(ChangeColors(Color.red, new Color(0.3f, 0, 0), currentState));
//                    }
//                    break;
//                case ColorState.Green:
//                    {
//                        StartCoroutine(ChangeColors(new Color(0.7f, 1.0f, 0.7f), new Color(0.3f, 0.5f, 0.3f), currentState));
//                    }
//                    break;
//                case ColorState.Orange:
//                    {
//                        StartCoroutine(ChangeColors(new Color(1.0f, 0.6f, 0.2f), new Color(1.0f, 0.8f, 0.0f), currentState));
//                    }
//                    break;
//                case ColorState.Yellow:
//                    {
//                        StartCoroutine(ChangeColors(new Color(1.0f, 1.0f, 0.7f), new Color(0.5f, 0.5f, 0.3f), currentState));
//                    }
//                    break;
//                default:
//                    break;
//            }
//            lastState = currentState;
//        }
//    }

//    private void RunAssignments()
//    {
//        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionRedZone += ChangeColourToRed;
//        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionOrangeZone += ChangeColourToOrange;
//        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionYellowZone += ChangeColourToYellow;
//        GameManager.instance.CollisionEvent.OnPlayerPlaneCollisionGreenZone += ChangeColourToGreen;
//    }
//}


