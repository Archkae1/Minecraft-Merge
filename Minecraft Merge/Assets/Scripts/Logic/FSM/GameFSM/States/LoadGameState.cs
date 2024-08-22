using UnityEngine;

public class LoadGameState : IGameState
{
    private GameInstance _gameInstance;
    private GameInstanceView _gameInstanceView;
    private GameStateMachine _gameStateMachine;
    private PlayerController _playerController;
    private GameUI _gameUI;
    private Score _score;

    public LoadGameState(GameInstance gameInstance, GameInstanceView gameInstanceView, GameStateMachine gameStateMachine, PlayerController playerController, GameUI gameUI, Score score)
    {
        _gameInstance = gameInstance;
        _gameStateMachine = gameStateMachine;
        _playerController = playerController;
        _gameUI = gameUI;
        _score = score;
        _gameInstanceView = gameInstanceView;
    }

    public void Enter()
    {
        _score.Load();
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
