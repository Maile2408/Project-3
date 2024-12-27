using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CompleteLevel()
    {
        GameManager.Instance.PauseGame();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasVictory>();
        UnlockNewLevel();
    }

    public void FailLevel()
    {
        GameManager.Instance.PauseGame();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasFail>();
    }
}