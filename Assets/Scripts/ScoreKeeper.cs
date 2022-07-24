using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswer = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
    public void IncrementCorrectAnswer()
    {
        correctAnswer++;
    }

    public int GetQuestionsSeen()
    {
        return questionsSeen;
    }
    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        //return ((100 / questionsSeen) * correctAnswer);
        return Mathf.RoundToInt(correctAnswer / (float)questionsSeen * 100);
    }


}
