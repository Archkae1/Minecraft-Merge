using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMP_Text _scoreText;

    public void Load() => _scoreText = GetComponent<TMP_Text>();

    private void OnScoreChanged(int score) => _scoreText.text = score.ToString();

    private void OnEnable() => Score.scoreChanged += OnScoreChanged;

    private void OnDisable() => Score.scoreChanged -= OnScoreChanged;
}
