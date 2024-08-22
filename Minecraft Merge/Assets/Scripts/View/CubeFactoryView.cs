using UnityEngine;

public class CubeFactoryView : MonoBehaviour
{
    [SerializeField] private GameObject _mergeFXPrefab;
    [SerializeField] private AudioSource _mergeSound;

    public void CreateMergeEffect(Transform collidedCube, Transform collisionCube)
    {
        Vector3 effectPosition = (collidedCube.position + collisionCube.position) / 2;
        Instantiate(_mergeFXPrefab, effectPosition, Quaternion.identity);
        PlayMergeSound();
    }

    private void PlayMergeSound()
    {
        _mergeSound.Play();
    }
}
