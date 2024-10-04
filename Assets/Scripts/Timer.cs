using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Action OnTimerEnd;
    [SerializeField] float _maxTimer = 5.0f;
    [SerializeField] TMP_Text _timerText;
    bool _disableTimer = false;
    
    public float timer;

    void Start() {
        timer = _maxTimer;
        _disableTimer = false;
    }

    void Update() {
        if (timer > 0 && !_disableTimer) {
            timer -= Time.deltaTime;
            _timerText.text = ((int)MathF.Ceiling(timer)).ToString();
            gameObject.GetComponent<Image>().fillAmount = timer / _maxTimer;
        } else if (timer <= 0 && !_disableTimer) {
            OnTimerEnd.Invoke();
        }
    }    

    public void TimerActive(bool b) {
        _disableTimer = !b;
    }

    public void ResetTime() {
        timer = _maxTimer;
    }
}

