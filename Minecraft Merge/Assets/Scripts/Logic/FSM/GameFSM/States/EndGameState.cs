using System.Collections;
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
        _gameUI.StartCoroutine(LateFullscreenAdShow());
    }

    public void Exit()
    {

    }

    private IEnumerator LateFullscreenAdShow()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        YandexGame.FullscreenShow();
    }
}
