using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private ScoreData _scoreData;

    private PlayerController _playerController;
    private GameUI _gameUI;
    private Score _score;

    private GameStateMachine _gameStateMachine;
    private GameInstanceView _view;

    private void Awake()
    {
        DefineComponents();
        _gameStateMachine.Enter<LoadGameState>();
    }

    private void Update()
    {
        if (_gameStateMachine.currentTypeOfState == typeof(PauseGameState) ||
            _gameStateMachine.currentTypeOfState == typeof(EndGameState))
            Time.timeScale = 0f;
    }

    public void Pause(bool showAd = true)
    {
        if (_gameStateMachine.currentTypeOfState != typeof(PauseGameState))
        {
            _gameStateMachine.Enter<PauseGameState>();
            if (showAd) YandexGame.FullscreenShow();
        }
    }

    public void UnPause()
    {
        if (_gameStateMachine.currentTypeOfState != typeof(PlayGameState))
            _gameStateMachine.Enter<PlayGameState>();
    }

    public void EndGame()
    {
        if (_gameStateMachine.currentTypeOfState != typeof(EndGameState))
            _gameStateMachine.Enter<EndGameState>();
    }

    public void Restart(bool showAd = true)
    {
        if (showAd) YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(0);
    }

    public void RestartWithSave(int rewVideoID)
    {
        if (rewVideoID == 1)
        {
            _scoreData.savedScore = _score.score;
            Restart(false);
        }
    }

    private void OnCubeTriggeredUpBorder()
    {
        if (_gameStateMachine.currentTypeOfState != typeof(EndGameState))
            EndGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) Pause(false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Pause(false);
    }

    private void DefineComponents()
    {
        _playerController = FindObjectOfType<PlayerController>(true);
        _gameUI = FindObjectOfType<GameUI>();
        _score = GetComponent<Score>();
        _view = GetComponent<GameInstanceView>();
        _gameStateMachine = new GameStateMachine(this, _view, _playerController, _gameUI, _score, _scoreData);
    }

    private void OnEnable()
    {
        Cube.cubeTriggeredUpBorder += OnCubeTriggeredUpBorder;
        YandexGame.RewardVideoEvent += RestartWithSave;
    }

    private void OnDisable() 
    { 
        Cube.cubeTriggeredUpBorder -= OnCubeTriggeredUpBorder;
        YandexGame.RewardVideoEvent -= RestartWithSave;
    }
}
