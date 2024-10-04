using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionAnswer {
    public string question;
    public string[] choices;
    public Answer correctAnswer;
    public string correctResponse;
    public string wrongResponse;

    public QuestionAnswer(string question) {
        this.question = question;
    }

    public void SetChoices(string choiceA, string choiceB, string choiceC, string choiceD, Answer correctAnswer) {
        choices = new string[4] {choiceA, choiceB, choiceC, choiceD};
        this.correctAnswer = correctAnswer;
    }
}

public enum Answer {
    A,
    B,
    C,
    D
}