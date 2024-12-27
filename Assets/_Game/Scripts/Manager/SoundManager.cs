using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Thêm để truy cập Scene

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource introSource, loopSource;

    // Start is called before the first frame update
    void Start()
    {
        // Kiểm tra nếu Scene hiện tại là một Level (Level 1, Level 2, ...)
        if (IsLevelScene())
        {
            introSource.Play();
            loopSource.PlayScheduled(AudioSettings.dspTime + introSource.clip.length);
        }
    }

    public void PauseMusic()
    {
        introSource.Pause();
        loopSource.Pause();
    }

    public void ResumeMusic()
    {
        introSource.UnPause();
        loopSource.UnPause();
    }

    // Kiểm tra nếu Scene hiện tại là một Level (Level 1, Level 2,...)
    private bool IsLevelScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        return sceneName.StartsWith("Level");  // Kiểm tra nếu tên Scene bắt đầu bằng "Level"
    }
}