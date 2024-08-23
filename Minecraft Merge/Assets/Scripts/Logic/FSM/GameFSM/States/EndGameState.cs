using UnityEngine;
using YG;

public class EndGameState : IGameState
{
    private GameUI _gameUI;
    private GameInstanceView _gameInstanceView;

    public EndGameState(GameUI gameUI, GameInstanceView gameInstanceView)
    {
        _gameUI = gameUI;
        _gameInstanceView = gameInstanceView;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _gameUI.EnableEndMenu();
        _gameInstanceView.PlayEndSound();
        YandexGame.FullscreenShow();
    }

    public void Exit()
    {

    }
}
