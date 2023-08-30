//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using Random = System.Random;

//public class Calculator : MonoBehaviour
//{
//    [SerializeField] TextMeshProUGUI multiplicationQuestion;
//    [SerializeField] TMP_InputField playerAnswer;
//    //[SerializeField] CountdownTimer countDownTimer;

//    private int[] numbersForMathsQuestions = new int[2];
//    private int correctAnswer;
//    private int playerAnswerAsInt = 0;
//    //private float countDown = 3f;

//    private const int ANSWERS_REQUIRED = 5;
//    private int correctAnswerCount;

//    private static readonly Random RandomNumberGenerator = new Random();


//    public float CorrectAnswer
//    { get { return correctAnswer; } }

//    //private void Awake()
//    //{
//    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ResetPlayerTextEntry;
//    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ResetPlayerTextEntry;
//    //    GameManager.instance.mathEvents.OnPlayerCorrectAnswer += ActivatePlayerTextEntry; 
//    //    GameManager.instance.mathEvents.OnPlayerIncorrectAnswer += ActivatePlayerTextEntry; 
//    //}

//    private void Start()
//    {
//        //GameManager.instance.CollisionEvent.OnPlayerCollisionMathsLevel += RunMathsFunctions;
//        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += IncrementCorrectAnswerCount;
//        GameManager.instance.mathEvents.OnPlayerCorrectAnswer += RunMathsFunctions;
//        GameManager.instance.mathEvents.OnTimeUp += RunMathsFunctions;
//        //SelectPlayerTextEntry();
//        //RunMathsFunctions();
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Return))
//        {
//            playerAnswerAsInt = ConvertPlayerAnswerToInt(playerAnswer, playerAnswerAsInt);
//            CheckIfAnswerIsCorrect(playerAnswerAsInt, correctAnswer);
//            GameManager.instance.mathEvents.CallPlayerAnswerSubmitted();
//        }
//        if (correctAnswerCount == ANSWERS_REQUIRED) 
//        {
//            GameManager.instance.mathEvents.CallPlayerFinishedMathsScene();
//        }

//    }

//    public static int GetRandomNumber(int min, int max)
//    {
//        lock (RandomNumberGenerator)
//        {
//            int result = RandomNumberGenerator.Next(min, max);
//            Debug.Log(result);
//            return result;
//        }
//    }

//    private void AnswerRandomMultiplicationQuestion(int[] array)
//    {
//        int result = array[0] * array[1];
//        correctAnswer = result;
//    }

//    private int[] GenerateRandomMultiplicationQuestion(int[] array)
//    {
//        int firstNumber = GetRandomNumber(4, 12);
//        int secondNumber = GetRandomNumber(4, 12);

//        array[0] = firstNumber;
//        array[1] = secondNumber;

//        return array;
//    }

//    private void ConvertMultiplicationQuestionToText(int[] array)
//    {
//        multiplicationQuestion.text = $"{array[0]} x {array[1]} = ?";
//    }

//    private void CheckIfAnswerIsCorrect(int answer, int correctAnswer)
//    {
//        if (answer == correctAnswer && countDownTimer.CountDownTime > 0)
//        {
//            GameManager.instance.mathEvents.CallPlayerCorrectAnswer();
//            Debug.Log("Correct!");
//        }
//        else if (answer == correctAnswer && countDownTimer.CountDownTime <= 0)
//        {
//            GameManager.instance.mathEvents.CallPlayerCorrectAnswerTooLate();
//            Debug.Log("Correct but too late.");
//        }
//        else
//        {
//            GameManager.instance.mathEvents.CallPlayerIncorrectAnswer();
//            Debug.Log("Incorrect. The correct answer is " + correctAnswer);
//        }


//        Debug.Log($"Your answer: {answer}, Correct Answer: {correctAnswer}");
//    }

//    private int ConvertPlayerAnswerToInt(TMP_InputField playerAnswer, int playerAnswerAsInt)
//    {
//        int.TryParse(playerAnswer.text, out playerAnswerAsInt);
//        Debug.Log($"Player Answer after conversion: {playerAnswerAsInt}");
//        return playerAnswerAsInt;
//    }


//    private void RunMathsFunctions()
//    {
//        GenerateRandomMultiplicationQuestion(numbersForMathsQuestions);
//        AnswerRandomMultiplicationQuestion(numbersForMathsQuestions);
//        ConvertMultiplicationQuestionToText(numbersForMathsQuestions);
//    }

//    //private void ResetPlayerTextEntry()
//    //{
//    //    playerAnswer.text = "";
//    //}

//    //private void ActivatePlayerTextEntry()
//    //{
//    //    playerAnswer.ActivateInputField();
//    //}

//    //private void SelectPlayerTextEntry()
//    //{
//    //    playerAnswer.Select();
//    //}

//    private void ResetText()
//    {
//        playerAnswer.text = string.Empty;
//    }
   

 
//    private void IncrementCorrectAnswerCount()
//    {
//        correctAnswerCount++;
//    }


//}


