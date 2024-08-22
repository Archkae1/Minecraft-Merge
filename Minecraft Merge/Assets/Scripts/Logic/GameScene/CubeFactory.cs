using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    public static Action<int> cubesMerged;

    [SerializeField] private List<Cube> _cubePrefabs = new List<Cube>();
    [SerializeField] private int _cubeLayer, _downBorderLayer, _upBorderLayer;
    private Cube _lastMergedCube;

    private CubeFactoryView _cubeFactoryView => GetComponent<CubeFactoryView>();

    public void MergeCubes(Cube collidedCube, Cube collisionCube)
    {
        if (collisionCube == _lastMergedCube || collidedCube == _lastMergedCube) return;

        int newCubeSpawnIndex = collidedCube.hierarchy + 1;
        if (newCubeSpawnIndex < _cubePrefabs.Count)
        {
            ReplaceCube(CreateNewCube(newCubeSpawnIndex), collidedCube);
            cubesMerged?.Invoke(newCubeSpawnIndex);
            _cubeFactoryView.CreateMergeEffect(collidedCube.transform, collisionCube.transform);

            DestroyOldCubes(collidedCube, collisionCube);
            _lastMergedCube = collidedCube;
        }
    }

    public Cube CreateNewCube(int spawnIndex)
    {
        Cube newCube = Instantiate(_cubePrefabs[spawnIndex]);
        newCube.Load(this, spawnIndex, _cubeLayer, _downBorderLayer, _upBorderLayer);
        newCube.StopMoving();
        return newCube;
    }

    private void ReplaceCube(Cube newCube, Cube oldCube)
    {
        newCube.StartMoving();
        newCube.transform.position = oldCube.transform.position;
        newCube.transform.rotation = oldCube.transform.rotation;
    }

    private void DestroyOldCubes(Cube collidedCube, Cube collisionCube) 
    {
        collidedCube.transform.DOKill();
        collidedCube.transform.DOKill();
        Destroy(collidedCube.gameObject);
        Destroy(collisionCube.gameObject);
    }
}
