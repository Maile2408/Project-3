using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
        SoundManager.Instance.PauseMusic();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.ResumeMusic();
    }

    public void OnExitGame(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            #if (UNITY_EDITOR || DEVELOPMENT_BUILD) // Chỉ dùng trong Unity Editor và Build phát triển
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            #endif

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Dừng trò chơi trong Unity Editor
            #elif UNITY_STANDALONE
                Application.Quit(); // Thoát game khi build cho Standalone
            #elif UNITY_WEBGL
                SceneManager.LoadScene("QuitScene"); // Tải scene QuitScene trong WebGL
            #endif
        }
    }
}
