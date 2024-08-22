using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private HighScoreText _highScoreText;

    public void Load(Score score)
    {
        DefineComponents();
        _highScoreText.Load(score);
    }

    public void Enable()
    {
        _highScoreText.DefineHighScoreText();
        gameObject.SetActive(true);
    }

    public void Disable() => gameObject.SetActive(false);

    private void DefineComponents() => _highScoreText = GetComponentInChildren<HighScoreText>(true);
}
