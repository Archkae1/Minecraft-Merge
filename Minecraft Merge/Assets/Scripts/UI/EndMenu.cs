using UnityEngine;

public class EndMenu : MonoBehaviour
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

    private void DefineComponents()
    {
        _highScoreText = GetComponentInChildren<HighScoreText>(true);
    }
}
