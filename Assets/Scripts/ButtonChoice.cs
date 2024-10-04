using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChoice : MonoBehaviour {
    public void DisableButton() {
        GetComponent<Button>().interactable = false;
    }

    public void EnableButton() {
        GetComponent<Button>().interactable = true;
    }

    public void StartQuiz() {
        SceneManager.LoadScene(1);
    }
}
