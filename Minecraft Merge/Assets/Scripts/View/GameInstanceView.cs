using UnityEngine;

public class GameInstanceView : MonoBehaviour
{
    [SerializeField] private AudioSource _minecraftMusic, _buttonSound, _endSound;
    private AudioListener _audioListener;

    public void Load() => DefineComponents();

    public void PlayButtonSound()
    {
        if (_audioListener.enabled) _buttonSound.Play();
    }
    public void PlayEndSound()
    {
        if (_audioListener.enabled) _endSound.Play();
    }
    public void PlayMusic()
    {
        if (_audioListener.enabled) _minecraftMusic.Play();
    }

    public void PauseMusic() => _minecraftMusic.Pause();

    private void DefineComponents() => _audioListener = FindObjectOfType<AudioListener>();
}
