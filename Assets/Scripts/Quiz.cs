using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionBox;
    [SerializeField] TextMeshProUGUI questionNumber;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    int totalNumberOfQuestions;

    [Header("Answers")]
    [SerializeField] GameObject[] answerOptions;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button color")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        totalNumberOfQuestions = (questions.Count);
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;

            
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }

        
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnsIndex())
        {
            questionBox.text = "Correct!";
            buttonImage = answerOptions[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswer();
        }
        else
        {
            //Change in the questionBox with correct answer as a string.
            correctAnswerIndex = currentQuestion.GetCorrectAnsIndex();
            string correctAnswer = currentQuestion.GetOptions(correctAnswerIndex);
            questionBox.text = "Wrong!!...Correct answer is - \n" + correctAnswer;

            //Highlight the correct option by an image if wrong ans is selected.
            buttonImage = answerOptions[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void DisplayQuestions()
    {
        questionBox.text = currentQuestion.GetQuestion();
        questionNumber.text = "Question Number - " + (totalNumberOfQuestions - questions.Count);

        for (int i = 0; i < answerOptions.Length; i++)
        {
            TextMeshProUGUI answerButton = answerOptions[i].GetComponentInChildren<TextMeshProUGUI>();
            answerButton.text = currentQuestion.GetOptions(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = ("Score: " + scoreKeeper.CalculateScore() + "%");

    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerOptions.Length; i++)
        {
            Button button = answerOptions[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestions();
            progressBar.value++;
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void SetDefaultButtonSprites()
    {
        Image defaultButtonImage;

        for (int i = 0; i < answerOptions.Length; i++)
        {
            defaultButtonImage = answerOptions[i].GetComponent<Image>();
            defaultButtonImage.sprite = defaultAnswerSprite;
        }
    }


}
