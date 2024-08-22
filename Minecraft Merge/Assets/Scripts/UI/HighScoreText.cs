using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    private Score _score;
    private TMP_Text _highScoreText;

    public void Load(Score score)
    {
        _score = score;
        _highScoreText = GetComponent<TMP_Text>();
    }

    public void DefineHighScoreText()
    {
        _highScoreText.text = _score.DefineHighScore().ToString();
    }
}
