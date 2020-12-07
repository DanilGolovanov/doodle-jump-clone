using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField, Tooltip("GameScene")]
    private string gameScene;

    [SerializeField]
    private InputField playerNameInput;
    [SerializeField]
    private Text hightScoreText;

    public string playerName = "noName";
    public float highScore;

    [SerializeField]
    private SettingsMenu settings;

    private PlayerData playerData;

    private void Start()
    {
        settings.LoadPlayerPrefs();

        playerData = SaveSystem.LoadPlayerData();
        if (playerData != null)
        {
            playerNameInput.text = playerData.loadedPlayerName;
            hightScoreText.text = Mathf.Round(playerData.loadedhighScore).ToString();
        }
    }

    public void StartGame()
    {
        // save player's name & high score
        playerName = playerNameInput.text;
        if (playerData != null)
        {
            highScore = playerData.loadedhighScore;
        }
        else
        {
            highScore = 0;
        }
        
        SaveSystem.SavePlayerData(this);
        // open game scene from main menu
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        // quit game in unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // quit game in the final build
        Application.Quit();
    }
}
