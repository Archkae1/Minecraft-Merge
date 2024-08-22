using System.Collections;
using UnityEngine;
using YG;

public class PauseGameState : IGameState
{
    private GameUI _gameUI;

    public PauseGameState(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _gameUI.EnablePauseMenu();
        _gameUI.StartCoroutine(LateFullscreenAdShow());
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _gameUI.DisablePauseMenu();
    }

    private IEnumerator LateFullscreenAdShow()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        YandexGame.FullscreenShow();
    }
}
