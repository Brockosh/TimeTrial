using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Calculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI multiplicationQuestion;
    [SerializeField] TMP_InputField playerAnswer;

    private int[] numbersForMathsQuestions = new int[2];
    private int correctAnswer;
    private int playerAnswerAsInt = 0;

    private static readonly Random RandomNumberGenerator = new Random();

    //private void Awake()
    //{
    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ResetPlayerTextEntry;
    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ResetPlayerTextEntry;
    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ActivatePlayerTextEntry; 
    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ActivatePlayerTextEntry; 
    //}

    private void Start()
    {
        GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += RunMathsFunctions;
        //SelectPlayerTextEntry();
        //RunMathsFunctions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerAnswerAsInt = ConvertPlayerAnswerToInt(playerAnswer, playerAnswerAsInt);
            CheckIfAnswerIsCorrect(playerAnswerAsInt, correctAnswer);
        }

    }

    public static int GetRandomNumber(int min, int max)
    {
        lock (RandomNumberGenerator)
        {
            int result = RandomNumberGenerator.Next(min, max);
            Debug.Log(result);
            return result;
        }
    }

    private void AnswerRandomMultiplicationQuestion(int[] array)
    {
        int result = array[0] * array[1];
        correctAnswer = result;
    }

    private int[] GenerateRandomMultiplicationQuestion(int[] array)
    {
        int firstNumber = GetRandomNumber(4, 12);
        int secondNumber = GetRandomNumber(4, 12);

        array[0] = firstNumber;
        array[1] = secondNumber;

        return array;
    }

    private void ConvertMultiplicationQuestionToText(int[] array)
    {
        multiplicationQuestion.text = $"{array[0]} x {array[1]} = ?";
    }

    private void CheckIfAnswerIsCorrect(int playerAnswer, int correctAnswer)
    {
        if (playerAnswer == correctAnswer)
        {
            GameManager.instance.mathEvents.CallPlayerCorrectAnswer();
            Debug.Log("Correct!");
            RunMathsFunctions();
        }
        else
        {
            GameManager.instance.mathEvents.CallPlayerIncorrectAnswer();
            Debug.Log("Incorrect. The correct answer is " + correctAnswer);
        }

        Debug.Log($"Your answer: {playerAnswer} Correct Answer: {correctAnswer}");
    }

    private int ConvertPlayerAnswerToInt(TMP_InputField playerAnswer, int playerAnswerAsInt)
    {
        int.TryParse(playerAnswer.text, out playerAnswerAsInt);
        Debug.Log($"Player Answer after conversion: {playerAnswerAsInt}");
        return playerAnswerAsInt;
    }


    private void RunMathsFunctions()
    {
        GenerateRandomMultiplicationQuestion(numbersForMathsQuestions);
        AnswerRandomMultiplicationQuestion(numbersForMathsQuestions);
        ConvertMultiplicationQuestionToText(numbersForMathsQuestions);
    }

    //private void ResetPlayerTextEntry()
    //{
    //    playerAnswer.text = "";
    //}

    //private void ActivatePlayerTextEntry()
    //{
    //    playerAnswer.ActivateInputField();
    //}

    //private void SelectPlayerTextEntry()
    //{
    //    playerAnswer.Select();
    //}

 



}


