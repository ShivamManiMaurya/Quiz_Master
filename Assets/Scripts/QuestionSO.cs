using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Write your question here";
    [SerializeField] string[] options = new string[4];
    [SerializeField] int correctAnsIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetOptions(int correctAnsIndex)
    {
        return options[correctAnsIndex];
    }

    public int GetCorrectAnsIndex()
    {
        return correctAnsIndex;
    }

}
