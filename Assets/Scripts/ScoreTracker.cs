using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {
    [SerializeField] GameManager _gameManager;
    [SerializeField] TMP_Text _scoreText;
    public int currentScore;
    public int maxScore;
    void Start() {
        maxScore = _gameManager.questionList.Count;
        currentScore = 0;
        _scoreText.text = $"Score: {currentScore} / {maxScore}";

        DontDestroyOnLoad(gameObject);
    }

    public void ScoreUp() {
        currentScore++;
        _scoreText.text = $"Score: {currentScore} / {maxScore}";
    }
}
