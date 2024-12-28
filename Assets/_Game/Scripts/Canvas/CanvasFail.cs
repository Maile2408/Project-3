using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFail : UICanvas
{
    public void ReplayButton()
    {
        // Lấy tên của Level hiện tại
        string currentLevelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentLevelName);
        GameManager.Instance.ResumeGame();
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    public void MapButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Close(0);
        UIManager.Instance.OpenUI<CanvasMap>();
    }
}
