using UnityEngine;
using UnityEngine.UI;
using YG;

public class SoundButton : MonoBehaviour
{
    private Image _iconImage;
    private GameInstanceView _gameInstanceView;
    private AudioListener _audioListener;

    public void Load() => DefineComponents();

    public void ChangeSoundsVolume()
    {
        if (_audioListener.enabled) TurnOffSounds();
        else TurnOnSounds();
        YandexGame.FullscreenShow();
    }

    private void ChangeSprite(bool isSoundEnabled)
    {
        if (isSoundEnabled) _iconImage.color = Color.white;
        else _iconImage.color = Color.red;
    }

    private void TurnOffSounds()
    {
        _audioListener.enabled = false;
        _gameInstanceView.PauseMusic();
        ChangeSprite(false);
    }

    private void TurnOnSounds()
    {
        _audioListener.enabled = true;
        _gameInstanceView.PlayMusic();
        _gameInstanceView.PlayButtonSound();
        ChangeSprite(true);
    }

    private void DefineComponents()
    {
        _iconImage = GetComponentsInChildren<Image>()[1];
        _gameInstanceView = FindObjectOfType<GameInstanceView>();
        _audioListener = FindObjectOfType<AudioListener>();
    }
}
