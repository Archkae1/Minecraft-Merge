using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour 
{
    public static Action<int> nextCubeChanged;

    [SerializeField] private Transform _cubeSpawnPoint, _rightBorder, _leftBorder;
    private CubeFactory _cubeFactory;
    private Cube _cube;
    private int _nextHierarchy, _maxSpawnHierarchy;

    public void Load()
    {
        DefineComponents();
        _maxSpawnHierarchy = 3;
    }

    public void ChangeXPosition(float x)
    {
        if (x > _rightBorder.position.x) x = _rightBorder.position.x;
        else if (x < _leftBorder.position.x) x = _leftBorder.position.x;
        transform.position = new Vector2(x, transform.position.y);
    }

    public void SpawnCube(bool isFirstSpawn)
    {
        if (!isFirstSpawn) _cube = _cubeFactory.CreateNewCube(_nextHierarchy);
        else
        {
            _cube = _cubeFactory.CreateNewCube(UnityEngine.Random.Range(0, _maxSpawnHierarchy));
        }
        _cube.transform.position = _cubeSpawnPoint.position;
        _cube.transform.parent = transform;

        _nextHierarchy = UnityEngine.Random.Range(0, _maxSpawnHierarchy);
        nextCubeChanged?.Invoke(_nextHierarchy);
    }

    public void DismissCube()
    {
        _cube.transform.parent = null;
        _cube.StartMoving();
        _cube = null;
    }

    private void DefineComponents() => _cubeFactory = FindObjectOfType<CubeFactory>();
}
