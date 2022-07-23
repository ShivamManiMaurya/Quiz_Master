using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;    

    float timeValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timeValue <= 0)
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowCorrectAnswer;
            }
        }
        else
        {

            if (timeValue <= 0)
            {
                isAnsweringQuestion = true;
                timeValue = timeToCompleteQuestion;
            }
        }


        Debug.Log("time value = "+timeValue);
    }
}
