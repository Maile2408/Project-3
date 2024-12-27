using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasQuitGame : UICanvas
{
    public void YesButton()
    {
        // Thoát game
        Application.Quit();
    }

    public void NoButton()
    {
        Close(0);
        if(IsLevelScene())
        {
            UIManager.Instance.OpenUI<CanvasPauseMenu>();
        }
        else 
        {
            UIManager.Instance.OpenUI<CanvasMainMenu>();
        }
    }

    private bool IsLevelScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        return sceneName.StartsWith("Level");  // Kiểm tra nếu tên Scene bắt đầu bằng "Level"
    }
}
