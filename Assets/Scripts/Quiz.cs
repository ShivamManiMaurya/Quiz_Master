using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionBox;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerOptions;

    void Start()
    {
        questionBox.text = question.GetQuestion();

        for (int i = 0; i < answerOptions.Length; i++)
        {
            TextMeshProUGUI answerButton = answerOptions[i].GetComponentInChildren<TextMeshProUGUI>();
            answerButton.text = question.GetOptions(i);
        }
    }
}
