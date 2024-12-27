using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMainMenu : UICanvas
{
    public void StartButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMap>();
    }

    public void HelpButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasHelp>();
    }

    public void QuitButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasQuitGame>();
    }
}
