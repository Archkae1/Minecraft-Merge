using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCubePanel : MonoBehaviour
{
    [SerializeField] private List<Sprite> _cubeSprites;
    [SerializeField] private Sprite _startSprite;
    private Image _nextCubeImage;

    public void Load()
    {
        DefineComponents();
        _nextCubeImage.sprite = _startSprite;
    }

    private void OnNextCubeChanged(int nextCubeHierarchy)
    {
        _nextCubeImage.sprite = _cubeSprites[nextCubeHierarchy];
    }

    private void DefineComponents()
    {
        _nextCubeImage = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        PlayerModel.nextCubeChanged += OnNextCubeChanged;
    }

    private void OnDisable()
    {
        PlayerModel.nextCubeChanged -= OnNextCubeChanged;
    }
}
