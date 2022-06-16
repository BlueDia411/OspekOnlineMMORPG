﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

     public void Answer()
    {
        if(isCorrect)
        {
            // GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();
            
        }
        else
        {
            // GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
