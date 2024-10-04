using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public UnityEvent onDisableChoices;
    public UnityEvent onEnableChoices;
    [SerializeField] TMP_Text _questionText;
    [SerializeField] TMP_Text _choiceAText;
    [SerializeField] TMP_Text _choiceBText;
    [SerializeField] TMP_Text _choiceCText;
    [SerializeField] TMP_Text _choiceDText;
    [SerializeField] TMP_Text _questionNumberText;
    [SerializeField] GameObject _responsePanel;
    [SerializeField] TMP_Text _responseText;
    [SerializeField] Timer _timer;
    [SerializeField] ScoreTracker _scoreTracker;

    private int _currentQuestion;
    public List<QuestionAnswer> questionList = new List<QuestionAnswer>();

    void Start() {
        _responsePanel.SetActive(false);
        StartGame();
        DisplayCurrentQuestion();
        _timer.OnTimerEnd += OnTimerEnd;
    }

    void OnDestroy() {
        _timer.OnTimerEnd += OnTimerEnd;
    }

    public void ChooseA() { StartCoroutine(ChooseChoice(Answer.A)); }
    public void ChooseB() { StartCoroutine(ChooseChoice(Answer.B)); }
    public void ChooseC() { StartCoroutine(ChooseChoice(Answer.C)); }
    public void ChooseD() { StartCoroutine(ChooseChoice(Answer.D)); }

    public void OnTimerEnd() {
        StartCoroutine(TimerEnd());
    }
    public IEnumerator TimerEnd() {
        _timer.TimerActive(false);
        _responsePanel.SetActive(true);

        onDisableChoices.Invoke();

        _responseText.text = "\"You're too slow!\" -Sonic, PhD in Speed";
        _responseText.color = Color.red;

        yield return new WaitForSeconds(3f);

        _responsePanel.SetActive(false);

        onEnableChoices.Invoke();
        NextQuestion();
    }

    public IEnumerator ChooseChoice(Answer choice) {
        _timer.TimerActive(false);
        _responsePanel.SetActive(true);

        onDisableChoices.Invoke();

        if (choice == questionList[_currentQuestion].correctAnswer) {
            _responseText.text = questionList[_currentQuestion].correctResponse;
            _responseText.color = new Color32(0x0F, 0x9D, 0x00, 0xFF);
            _scoreTracker.ScoreUp();
        } else {
            _responseText.text = questionList[_currentQuestion].wrongResponse;
            _responseText.color = Color.red;
        }

        yield return new WaitForSeconds(3.5f);

        _responsePanel.SetActive(false);

        onEnableChoices.Invoke();
        NextQuestion();
    }

    public void StartGame() {
        _currentQuestion = 0;
    }

    public void DisplayCurrentQuestion() {
        _questionNumberText.text = "#" + (_currentQuestion + 1);
        _questionText.text = questionList[_currentQuestion].question;
        _choiceAText.text = questionList[_currentQuestion].choices[0];
        _choiceBText.text = questionList[_currentQuestion].choices[1];
        _choiceCText.text = questionList[_currentQuestion].choices[2];
        _choiceDText.text = questionList[_currentQuestion].choices[3];
    }

    public void NextQuestion() {
        if (_currentQuestion + 1 >= questionList.Count) {
            SceneManager.LoadScene(2);
            return;
        }
        
        _currentQuestion++;

        DisplayCurrentQuestion();
        _timer.ResetTime();
        _timer.TimerActive(true);
    }
}