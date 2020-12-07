using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    public float score = 0;
    [SerializeField]
    private Text finalScoreText;

    [SerializeField]
    private Text highScoreText;
    public float highScore = 0;
    private bool newHighScore = false;

    private float startPosition;

    [SerializeField]
    private PlayerController player;
    private GameManager gameManager;

    public bool scoreIncreasing = false;

    public string playerName = "noName";
    [SerializeField]
    private Text playerNameText;

    private void Start()
    {
        LoadPlayerData();
        startPosition = player.transform.position.y;
        gameManager = FindObjectOfType<GameManager>();
        playerNameText.text = playerName;
    }

    private void Update()
    {
        if (scoreIncreasing)
        {
            // if score is less than the actual travelled distance, update it
            if (score < player.transform.position.y - startPosition)
            {
                score = player.transform.position.y - startPosition;
            }
            // if player moves up and the current score is bigger than the high score, update high score
            if (player.rigidbody2D.velocity.y > 0 && score > highScore)
            {
                highScore = score;
                newHighScore = true;
            }
            // kill player if he fell off the platform
            if (score > player.transform.position.y - startPosition + 30)
            {
                gameManager.FinishGame();
            }

            scoreText.text = "Score: " + Mathf.Round(score);
        }
        else
        {
            finalScoreText.text = Mathf.Round(score).ToString();
            highScoreText.text = Mathf.Round(highScore).ToString();
            if (newHighScore)
            {
                SavePlayerData();
                newHighScore = false;
            }
        }
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayerData()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            PlayerData data = SaveSystem.LoadPlayerData();
            playerName = data.loadedPlayerName;
            highScore = data.loadedhighScore;
        }
    }
}
