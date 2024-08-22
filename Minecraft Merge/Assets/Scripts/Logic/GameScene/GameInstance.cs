using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
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

    public void Pause()
    {
        if (_gameStateMachine.currentTypeOfState != typeof(PauseGameState))
            _gameStateMachine.Enter<PauseGameState>();
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCubeTriggeredUpBorder()
    {
        if (_gameStateMachine.currentTypeOfState != typeof(EndGameState))
            EndGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) Pause();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Pause();
    }

    private void DefineComponents()
    {
        _playerController = FindObjectOfType<PlayerController>(true);
        _gameUI = FindObjectOfType<GameUI>();
        _score = GetComponent<Score>();
        _view = GetComponent<GameInstanceView>();
        _gameStateMachine = new GameStateMachine(this, _view, _playerController, _gameUI, _score);
    }

    private void OnEnable() => 
        Cube.cubeTriggeredUpBorder += OnCubeTriggeredUpBorder;

    private void OnDisable() =>
        Cube.cubeTriggeredUpBorder -= OnCubeTriggeredUpBorder;
}
