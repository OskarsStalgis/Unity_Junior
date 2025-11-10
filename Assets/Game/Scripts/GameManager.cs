
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //Gave default values null so there are no game errors in scenes where i dont use all the objects
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private GameObject gameFinishedScreen = null;
    [SerializeField] private GameObject settingsButton = null;
    [SerializeField] private Timer timer = null;
    [SerializeField] private bool isPaused = false;

    public static GameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void LooseLife(bool shouldDie = false)
    {
        if (LifeManager.lifeCount > 0)
        {
            if (shouldDie)
            {
                LifeManager.lifeCount = 0;
            }
            else
            {
               LifeManager.lifeCount--;
            }
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.isHit = true;
                }
                if (LifeManager.lifeCount <= 0)
                {
                    playerMovement.isPlayerDead = true;
                }
            }
        }
    }

    public void GainLife()
    {
        if (LifeManager.lifeCount == 3)
        {
            ScoreManager.scoreCount++;
        }
        else if (LifeManager.lifeCount < 3)
        {
            LifeManager.lifeCount++;
        }
    }

    public void OpenMainMenu()
    {
        RestartScore();
        SceneManager.LoadScene(0);
    }
    
    public void StartLevelOne()
    {
        PauseGame(false);
        SceneManager.LoadScene(1);
        RestartScore();
    }

//Created this so i cant interract with game when in pause menu or end game menu.
    public void PauseGame(bool paused)
    {
        isPaused = paused;
        Time.timeScale = paused ? 0f : 1f;

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var playerInput = player.GetComponent<PlayerInput>();
            if (playerInput != null)
            {
                if (paused)
                    playerInput.DeactivateInput();
                else
                    playerInput.ActivateInput();
            }
        }
    }
    
    public void EnableGameOverScreen()
    {
        timer.isActive = false;
        settingsButton.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        RestartScore();
        SceneManager.LoadScene(gameObject.scene.name);
    }

    //This resets score when restarting the game
    public void RestartScore()
    {
        ScoreManager.scoreCount = 0;
        LifeManager.lifeCount = 3;
        Timer._currentTime = 0;
    }

    public void OnGameFinish()
    {
        settingsButton.SetActive(false);
        gameFinishedScreen.SetActive(true);
        PauseGame(true);
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
