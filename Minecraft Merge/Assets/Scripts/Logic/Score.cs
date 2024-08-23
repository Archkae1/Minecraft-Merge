using System;
using UnityEngine;
using YG;

public class Score : MonoBehaviour
{
    public static Action<int> scoreChanged;

    private int _score, _highScore;
    private ScoreData _scoreData;

    public int score { get { return _score; } }

    public void Load(ScoreData scoreData = null)
    {
        _score = 0;
        if (scoreData)
        {
            _scoreData = scoreData;
            _score = _scoreData.savedScore;
            _scoreData.savedScore = 0;
        }
        LoadHighScore();
    }

    public void AddScore(int mergedHierarchy)
    {
        _score += (int)Mathf.Pow(2, mergedHierarchy);
        scoreChanged?.Invoke(_score);
    }

    public int DefineHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            YandexGame.savesData.highscore = _highScore;
            YandexGame.NewLeaderboardScores("Highscore", _highScore);
            YandexGame.SaveProgress();
        }
        return _highScore;
    }

    private void OnCubesMerged(int mergedHierarchy)
    {
        AddScore(mergedHierarchy);
    }

    private void LoadHighScore()
    {
        _highScore = YandexGame.savesData.highscore;
    }

    private void OnEnable()
    {
        CubeFactory.cubesMerged += OnCubesMerged;
    }
    private void OnDisable()
    {
        CubeFactory.cubesMerged -= OnCubesMerged;
    }
}
