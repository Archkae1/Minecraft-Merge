using DG.Tweening;
using UnityEngine;

public class CubeView
{
    public void Load(int hierarchy, Transform transform)
    {
        float initialScale = 1 + hierarchy * 0.3f;
        ScaleUp(transform, initialScale);
    }

    private void ScaleUp(Transform transform, float initialScale)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(initialScale, 0.25f);
    }
}
