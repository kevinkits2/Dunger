using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button toMenuButton;

    [SerializeField] private GameObject pauseUIHolder;
    [SerializeField] private GameObject gameOverLostUIHolder;
    [SerializeField] private GameObject gameOverWonUIHolder;

    private void Awake() {
        //Resume the game from pause menu
        resumeButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            pauseUIHolder.SetActive(false);
        });

        //Exit the game loop and go to the menu
        toMenuButton.onClick.AddListener(() => {
            //AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        });
    }
}
