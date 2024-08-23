using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private Score _score;
    private TMP_Text _scoreText;

    public void Load()
    {
        DefineComponents();
        _scoreText.text = _score.score.ToString();
    }

    private void OnScoreChanged(int score) => _scoreText.text = score.ToString();

    private void DefineComponents()
    {
        _scoreText = GetComponent<TMP_Text>();
        _score = FindObjectOfType<Score>();
    }

    private void OnEnable() => Score.scoreChanged += OnScoreChanged;

    private void OnDisable() => Score.scoreChanged -= OnScoreChanged;
}
