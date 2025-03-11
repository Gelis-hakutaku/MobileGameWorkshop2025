using UnityEngine;

public class SelectProjectile : MonoBehaviour
{
    [SerializeField] private ProjectileIndex _projectileIndex;

    public void changeProjectile(int newIndex)
    {
        _projectileIndex.Index = newIndex;
    }
}
