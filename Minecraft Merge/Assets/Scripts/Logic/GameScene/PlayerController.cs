using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameInstance _gameInstance;
    private PlayerModel _playerModel;
    private bool _isCanEnablePlayer = false;

    public bool isCanEnablePlayer { set { _isCanEnablePlayer = value; } }

    public void Load()
    {
        _gameInstance = FindObjectOfType<GameInstance>();
        _playerModel = GetComponent<PlayerModel>();

        _playerModel.Load();
    }

    public void EnablePlayer(bool isFirstEnable = false)
    {
        _playerModel.SpawnCube(isFirstEnable);
        gameObject.SetActive(true);
    }

    public void DisablePlayer()
    {
        _playerModel.DismissCube();
        gameObject.SetActive(false);
        _gameInstance.StartCoroutine(LateCanEnablePlayer());
    }

    public void OnPointerDown()
    {
        if (!gameObject.activeSelf && _isCanEnablePlayer) EnablePlayer();
        _playerModel.ChangeXPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
    }

    public void OnDrag()
    {
        if (!gameObject.activeSelf && _isCanEnablePlayer) EnablePlayer();
        _playerModel.ChangeXPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
    }

    public void OnPointerUp()
    {
        if (gameObject.activeSelf) DisablePlayer();
    }

    private IEnumerator LateCanEnablePlayer()
    {
        _isCanEnablePlayer = false;
        yield return new WaitForSeconds(1.5f);
        _isCanEnablePlayer = true;
    }
}
