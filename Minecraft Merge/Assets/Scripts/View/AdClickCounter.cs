using UnityEngine;
using YG;

public class AdClickCounter : MonoBehaviour
{
    private int _currentDismissedCubes = 0;

    private void OnCubeDismissed()
    {
        _currentDismissedCubes++;
        if (_currentDismissedCubes % 8 == 0 && _currentDismissedCubes > 0)
        {
            YandexGame.FullscreenShow();
            _currentDismissedCubes = 0;
        }
    }

    private void OnEnable()
    {
        PlayerModel.cubeDismissed += OnCubeDismissed;
    }

    private void OnDisable()
    {
        PlayerModel.cubeDismissed -= OnCubeDismissed;
    }
}
