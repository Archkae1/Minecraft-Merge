using UnityEngine;

public class GameUI : MonoBehaviour
{
    private SoundButton _soundButton;
    private EndMenu _endMenu;
    private NextCubePanel _nextCubePanel;
    private PauseMenu _pauseMenu;
    private ScoreText _scoreText;

    public void Load(Score score)
    {
        DefineComponents();
        _soundButton.Load();
        _nextCubePanel.Load();
        _pauseMenu.Load(score);
        _endMenu.Load(score);
        _scoreText.Load();
    }

    public void EnablePauseMenu() => _pauseMenu.Enable();

    public void DisablePauseMenu() => _pauseMenu.Disable();

    public void EnableEndMenu() => _endMenu.Enable();

    private void DefineComponents()
    {
        _soundButton = GetComponentInChildren<SoundButton>();
        _nextCubePanel = GetComponentInChildren<NextCubePanel>();
        _pauseMenu = GetComponentInChildren<PauseMenu>(true);
        _endMenu = GetComponentInChildren<EndMenu>(true);
        _scoreText = GetComponentInChildren<ScoreText>();
    }
}
