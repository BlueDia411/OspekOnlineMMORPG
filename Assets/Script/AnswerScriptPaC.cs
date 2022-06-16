using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScriptPaC : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerPaC quizManagerPaC;

     public void Answer()
    {
        if(isCorrect)
        {
            // GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManagerPaC.correct();
            
        }
        else
        {
            // GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManagerPaC.wrong();
        }
    }
}
