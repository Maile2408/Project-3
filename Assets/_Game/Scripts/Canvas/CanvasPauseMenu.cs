using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPauseMenu : UICanvas
{
    public void ResumeButton()
    {
        GameManager.Instance.ResumeGame();
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    public void QuitButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasQuitGame>();
    }
}
