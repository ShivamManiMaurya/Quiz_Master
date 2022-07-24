using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;

    float timeValue;

    Quiz quiz;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
    }

    void Update()
    {
        if (!quiz.isComplete)
        {
            UpdateTimer();
        }
    }

    public void CancelTimer()
    {
        timeValue = 0;
    }

    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

    }
}
