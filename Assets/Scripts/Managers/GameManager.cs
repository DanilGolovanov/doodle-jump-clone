using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField, Tooltip("Player gameObject with attached PlayerController script.")]
    private PlayerController player;
    // initial position of the player
    private Vector3 playerStartPoint;

    private BouncePlatform[] platforms;

    private ScoreManager scoreManager;
    private PlatformManager platformManager;
    private Vector3 platformManagerStartPoint;

    [Tooltip("Death Menu gameObject with attached DeathMenu script.")]
    public DeathMenu deathMenu;

    private bool isStarted = false;

    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private Transform startPlatformsPosition;
    [SerializeField]
    private GameObject startPlatformsPrefab;

    [SerializeField]
    private SettingsMenu settings;

    #endregion

    #region Default Methods
    private void Start()
    {
        settings.LoadPlayerPrefs();

        // get initial values
        scoreManager = FindObjectOfType<ScoreManager>();
        platformManager = FindObjectOfType<PlatformManager>();

        playerStartPoint = player.transform.position;
        platformManagerStartPoint = platformManager.transform.position;
    }

    private void Update()
    {
        if (startScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    #endregion

    #region Custom Methods
    /// <summary>
    /// Stop scoring points, make player invisible and activate death menu when bird dies.
    /// </summary>
    public void FinishGame()
    {
        // stop scoring points when player dies
        scoreManager.scoreIncreasing = false;
        // when player dies make player invisible
        player.gameObject.SetActive(false);
        // activate death screen when player dies
        deathMenu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Reset player stats and position of player to initial values,
    /// destroy previously generated pipes and deactivate death menu.
    /// </summary>
    public void ResetGame()
    {
        // deactivate death screen
        deathMenu.gameObject.SetActive(false);
        // destroy all platforms that were created previously 
        platforms = FindObjectsOfType<BouncePlatform>();
        for (int i = 0; i < platforms.Length; i++)
        {
            Destroy(platforms[i].gameObject);
        }
        // instantiated first few platforms
        Instantiate(startPlatformsPrefab, startPlatformsPosition.position, startPlatformsPosition.rotation);
        // reset position of player
        player.transform.position = playerStartPoint;
        // reset position of platform manager
        platformManager.transform.position = platformManagerStartPoint;
        // make player visible again
        player.gameObject.SetActive(true);
        // set default rotation of the player
        player.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        // reset the score
        scoreManager.score = 0;
        scoreManager.scoreIncreasing = true;
        // activate start screen
        startScreen.SetActive(true);
        // make player motionless
        player.rigidbody2D.gravityScale = 0;
        player.rigidbody2D.velocity = Vector2.zero;
    }

    private void StartGame()
    {
        // deactivate start screen
        startScreen.SetActive(false);
        // return gravity scale to default value
        player.rigidbody2D.gravityScale = player.gravityScaleStore;
    }
    #endregion
}
