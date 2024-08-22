using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeHierarchyPanel : MonoBehaviour
{
    [SerializeField] private List<Image> _cubeHierarchyImages;

    private void OnCubesMerged(int newCubeHierarchy)
    {
        if (_cubeHierarchyImages[newCubeHierarchy].color == Color.black) 
            _cubeHierarchyImages[newCubeHierarchy].color = Color.white;
    }

    private void OnEnable() => CubeFactory.cubesMerged += OnCubesMerged;

    private void OnDisable() => CubeFactory.cubesMerged -= OnCubesMerged;
}
