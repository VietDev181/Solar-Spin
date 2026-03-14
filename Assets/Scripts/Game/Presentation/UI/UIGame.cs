using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioService audioService;

    public Button homeButton;
    public Button pauseButton;
    public Button settingButton;
    public Button resumeButton;
    public Button resumeSettingButton;
    public Button replayButton;
    public Button replayGameOverButton;

    [Header("UI Texts")]
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("UI Panel")]
    public GameObject pausePanel;
    public GameObject setttingPanel;
    public GameObject gameOverPanel;

    private void Start()
    {
        audioService.PlayGameBGM();

        homeButton.onClick.AddListener(OnHomeGame);
        pauseButton.onClick.AddListener(OnPauseGame);
        settingButton.onClick.AddListener(OnSettingGame);
        resumeButton.onClick.AddListener(OnResumeGame);
        resumeSettingButton.onClick.AddListener(OnResumeGame);
        replayButton.onClick.AddListener(OnReplayGame);
        replayGameOverButton.onClick.AddListener(OnReplayGame);

        pausePanel.SetActive(false);
        setttingPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    private void OnHomeGame()
    {
        audioService.PlayClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    private void OnPauseGame()
    {
        audioService.PlayClick();
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    private void OnSettingGame()
    {
        audioService.PlayClick();
        Time.timeScale = 0f;
        setttingPanel.SetActive(true);
    }

    private void OnResumeGame()
    {
        audioService.PlayClick();
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        setttingPanel.SetActive(false);
    }

    private void OnReplayGame()
    {
        Time.timeScale = 1f;
        audioService.PlayClick();
        audioService.PlayGameBGM();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void ShowGameOver(int currentScore, int highScore)
    {
        audioService.PlayGameOverBGM();
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        gameOverScoreText.text = "Score: " + currentScore;
        gameOverHighScoreText.text = "Best Score\n" + highScore;
    }
}
