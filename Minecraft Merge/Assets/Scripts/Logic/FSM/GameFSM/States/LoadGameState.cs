using UnityEngine;

public class LoadGameState : IGameState
{
    private GameInstance _gameInstance;
    private GameInstanceView _gameInstanceView;
    private GameStateMachine _gameStateMachine;
    private PlayerController _playerController;
    private GameUI _gameUI;
    private Score _score;
    private ScoreData _scoreData;

    public LoadGameState(GameInstance gameInstance, GameInstanceView gameInstanceView, GameStateMachine gameStateMachine, PlayerController playerController, GameUI gameUI, Score score, ScoreData scoreData)
    {
        _gameInstance = gameInstance;
        _gameStateMachine = gameStateMachine;
        _playerController = playerController;
        _gameUI = gameUI;
        _score = score;
        _gameInstanceView = gameInstanceView;
        _scoreData = scoreData;
    }

    public void Enter()
    {
        _score.Load(_scoreData);
        _gameUI.Load(_score);
        _playerController.Load();
        _gameInstanceView.Load();
        Time.timeScale = 1f;

        _gameStateMachine.Enter<PlayGameState>();
    }

    public void Exit()
    {

    }
}
