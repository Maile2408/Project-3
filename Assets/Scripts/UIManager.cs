using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public MusicPlayer musicPlayer;

    public Canvas gameCanvas;

    public void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }
    
    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }
    public void CharacterTookDamage(GameObject charater, int damageReceived)
    {
        // Create text at character hit
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(charater.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }
    
    public void CharacterHealed (GameObject charater, int healthRestored)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(charater.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = healthRestored.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        musicPlayer.ResumeMusic();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        musicPlayer.PauseMusic();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void HelpGame()
    {

    }
    
    public void OnExitGame(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            #endif

            #if (UNITY_EDITOR)
                    UnityEditor.EditorApplication.isPlaying = false;
            #elif (UNITY_STANDALONE)
                    Application.Quit();
            #elif (UNTY_WEBGL)
                    SceneManager.LoadScence("QuitScene");
            #endif
        }
    }
}