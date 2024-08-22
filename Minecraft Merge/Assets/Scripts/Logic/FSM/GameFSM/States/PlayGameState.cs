public class PlayGameState : IGameState
{
    private PlayerController _playerController;
    private GameInstanceView _gameInstanceView;
    private bool _isFirstEnter = true;

    public PlayGameState(PlayerController playerController, GameInstanceView gameInstanceView)
    {
        _playerController = playerController;
        _gameInstanceView = gameInstanceView;
    }

    public void Enter()
    {
        _playerController.enabled = true;
        if (_isFirstEnter) _playerController.isCanEnablePlayer = true;
        _gameInstanceView.PlayMusic();
    }

    public void Exit()
    {
        _playerController.enabled = false;
        _gameInstanceView.PauseMusic();
    }
}
