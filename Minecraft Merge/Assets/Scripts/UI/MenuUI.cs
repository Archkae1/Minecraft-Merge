using UnityEngine;

public class MenuUI : MonoBehaviour
{
    private HighScoreText _highScoreText;

    public void Load(Score score)
    {
        DefineComponents();
        _highScoreText.Load(score);
        _highScoreText.DefineHighScoreText();
    }

    private void DefineComponents()
    {
        _highScoreText = GetComponentInChildren<HighScoreText>();
    }
}
