using UnityEngine;

public class SelectProjectile : MonoBehaviour
{
    [SerializeField] private ShootScript shootScript;

    public void changeProjectile(GameObject projectile)
    {
        shootScript.projectile = projectile;
        StartCoroutine(shootScript.ReloadProjectile(0f));
    }
}
