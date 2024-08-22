using UnityEngine;

public class FX : MonoBehaviour
{
    private ParticleSystem _particleSystem => GetComponent<ParticleSystem>();

    private void Update()
    {
        if (_particleSystem.isStopped) Destroy(gameObject);
    }
}
