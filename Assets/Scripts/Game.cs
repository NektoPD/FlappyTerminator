using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _restartScreen;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _restartScreen.RestartButtonClicked += OnRestartButtonClicked;

        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _restartScreen.RestartButtonClicked -= OnRestartButtonClicked;

        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _restartScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _scoreCounter.ResetScore();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _bulletPool?.DeactivateAllBullets();
        _restartScreen.Open();
    }
}
