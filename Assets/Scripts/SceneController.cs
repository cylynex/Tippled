using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    ErrorHandler errorHandler;

    public void LoadLevel(string levelToLoad) {
        SceneManager.LoadScene(levelToLoad);
    }

    public void StartGame() {
        if (GameController.numberOfPlayers < 1) {
            GameObject.FindGameObjectWithTag("ErrorHandler").GetComponent<ErrorHandler>().SetErrorText("Need at least 1 player!");
        } else {
            SceneManager.LoadScene("HowToPlay");
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Settings() {
        SceneManager.LoadScene("Settings");
    }

}
