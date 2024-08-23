using UnityEngine;

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
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _gameUI.DisablePauseMenu();
    }
}
