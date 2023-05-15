using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void GamePlay() {
        SceneManager.LoadScene("Choose Level");
    }
    public void Level1() {
        SceneManager.LoadScene("Level 1");
    }
    public void Level2() {
        SceneManager.LoadScene("Level 2");
    }
    public void Level3() {
        SceneManager.LoadScene("Level 3");
    }

    public void ExitButton() {
        Application.Quit();
    }
}
