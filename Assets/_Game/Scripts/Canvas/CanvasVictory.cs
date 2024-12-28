using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVictory : UICanvas
{
    public void NextButton()
    {
        GameManager.Instance.ResumeGame();
        LevelManager.Instance.NextLevel();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}
