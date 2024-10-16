using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button toMenuPauseButton;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button toMenuLoseButton;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button toMenuWinButton;

    [SerializeField] private GameObject pauseUIHolder;
    [SerializeField] private GameObject gameOverLostUIHolder;
    [SerializeField] private GameObject gameOverWonUIHolder;

    private bool isPaused = false;

    private void Awake() {
        InputManagerEvents.OnPausePerformed += HandlePause;

        //Resume the game from pause menu
        resumeButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            HandlePause();
        });

        //Exit the game loop and go to the menu
        toMenuPauseButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        });

        //Retry the current level button
        retryButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        //To menu from lose screen button
        toMenuLoseButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        });

        //Load next level button
        nextButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        //To menu from win screen button
        toMenuLoseButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        });
    }

    private void HandlePause() {
        if (isPaused) {
            Time.timeScale = 1.0f;
        }
        else {
            Time.timeScale = 0.0f;
        }
        isPaused = !isPaused;
        pauseUIHolder.SetActive(isPaused);
    }
}
