using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionBox;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerOptions;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    //bool flag = true;

    void Start()
    {
        //DisplayQuestions();
        GetNextQuestion();
    }


    void DisplayQuestions()
    {
        questionBox.text = question.GetQuestion();

        for (int i = 0; i < answerOptions.Length; i++)
        {
            TextMeshProUGUI answerButton = answerOptions[i].GetComponentInChildren<TextMeshProUGUI>();
            answerButton.text = question.GetOptions(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnsIndex())
        {
            questionBox.text = "Correct!";
            buttonImage = answerOptions[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            //Change in the questionBox with correct answer as a string.
            correctAnswerIndex = question.GetCorrectAnsIndex();
            string correctAnswer = question.GetOptions(correctAnswerIndex);
            questionBox.text = "Wrong!!...Correct answer is - \n" + correctAnswer;

            //Highlight the correct option by an image if wrong ans is selected.
            buttonImage = answerOptions[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
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
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestions();
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
