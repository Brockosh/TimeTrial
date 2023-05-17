using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerAnswer : MonoBehaviour
{
    [SerializeField] TMP_InputField playerAnswer;


    //private void Awake()
    //{
    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ResetPlayerTextEntry;
    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ResetPlayerTextEntry;
    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ActivatePlayerTextEntry;
    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ActivatePlayerTextEntry;
    //}

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += ActivatePlayerTextEntry;


        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ResetPlayerTextEntry;
        GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ResetPlayerTextEntry;
        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ActivatePlayerTextEntry;
        GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ActivatePlayerTextEntry;
    
        SelectPlayerTextEntry();
        playerAnswer.onValidateInput += delegate (string text, int charIndex, char addedChar) { return ValidateNumberInput(addedChar); };
    }

    public int GetPlayerAnswer()
    {
        int playerAnswerAsInt = 0;
        int.TryParse(playerAnswer.text, out playerAnswerAsInt);
        Debug.Log($"Player Answer after conversion: {playerAnswerAsInt}");
        return playerAnswerAsInt;
    }

    public void ResetPlayerTextEntry()
    {
        playerAnswer.text = "";
    }

    public void ActivatePlayerTextEntry()
    {
        playerAnswer.ActivateInputField();
    }

    public void SelectPlayerTextEntry()
    {
        playerAnswer.Select();
        Debug.Log("Text entry selected");
    }

    private char ValidateNumberInput(char inputChar)
    {

        if (char.IsDigit(inputChar))
        {
            return inputChar;
        }

        return '\0'; 
    }


    //DisableCurrentScene




}


