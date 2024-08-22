using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public static Action cubeTriggeredUpBorder;

    [SerializeField] private Rigidbody2D _rigidbody;
    private int _cubeLayer, _upBorderLayer, _downBorderLayer, _hierarchy;
    private bool _isFall = false;
    private CubeFactory _cubeFactory;
    private CubeView _cubeView;

    public int hierarchy { get { return _hierarchy; } }

    public void Load(CubeFactory cubeFactory, int hierarchy, int cubeLayer, int downBorderLayer, int upBorderLayer)
    {
        DefineComponents(cubeFactory, hierarchy, cubeLayer, downBorderLayer, upBorderLayer);

        _cubeView.Load(hierarchy, transform);
    }
    
    public void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.gravityScale = 0f;
    }

    public void StartMoving() => _rigidbody.gravityScale = 1f;

    private void OnCollisionCube(Cube collidedCube, Cube collisionCube)
    {
        if (collisionCube.hierarchy == collidedCube.hierarchy)
        {
            _cubeFactory.MergeCubes(collidedCube, collisionCube);
        }
        else _isFall = true;
    }

    private void DefineComponents(CubeFactory cubeFactory, int hierarchy, int cubeLayer, int downBorderLayer, int upBorderLayer)
    {
        _cubeView = new CubeView();
        _cubeLayer = cubeLayer;
        _upBorderLayer = upBorderLayer;
        _downBorderLayer = downBorderLayer;
        _hierarchy = hierarchy;
        _cubeFactory = cubeFactory;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _cubeLayer)
            OnCollisionCube(this, collision.gameObject.GetComponent<Cube>());
        else if (collision.gameObject.layer == _downBorderLayer) _isFall = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isFall && collision.gameObject.layer == _upBorderLayer) cubeTriggeredUpBorder?.Invoke();
    }
}
