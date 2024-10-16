using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private Button backButton;

    [SerializeField] private GameObject settingsUIHolder;
    [SerializeField] private GameObject mainUIHolder;

    private void Awake() {
        //Start game from menu button
        startButton.onClick.AddListener(() => {
            AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);
        });

        //Swap to settings from menu button
        settingsButton.onClick.AddListener(() => {
            AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SwapUI(mainUIHolder, settingsUIHolder);
        });

        //Swap to menu from settings button
        backButton.onClick.AddListener(() => {
            AudioPlayer.Instance.ButtonClicked();
            Time.timeScale = 1.0f;
            SwapUI(settingsUIHolder, mainUIHolder);
        });

        //Exit game from menu button
        exitButton.onClick.AddListener(() => {
            AudioPlayer.Instance.ButtonClicked();
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        });
    }

    //Function for swapping UI visibility
    private void SwapUI(GameObject from, GameObject to) {
        from.SetActive(false);
        to.SetActive(true);
    }
}
