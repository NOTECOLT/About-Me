using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour {
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _flavorText;
    float _maxScore;
    float _score;

    void Start() {
        ScoreTracker st = FindObjectOfType<ScoreTracker>();
        _maxScore = st.maxScore;
        _score = st.currentScore;
        Destroy(st.gameObject);

        _scoreText.text = $"Score: {_score} / {_maxScore}";

        if (_score == 0) {
            _flavorText.text = "DUDE, a ZERO?? You suck.";
        } else if (_score/_maxScore < 0.5f) {
            _flavorText.text = "Yeah.. you don't know me at all... :(";
        } else if (_score/_maxScore >= 0.5f && _score/_maxScore < 1) {
            _flavorText.text = "Heyyy not bad! Good job <3";
        } else {
            _flavorText.text = "WOW! Perfect Score~ Congratulations!";
        }        
    }
}
