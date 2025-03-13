using UnityEngine;

public class SelectProjectile : MonoBehaviour
{
    [SerializeField] private ShootScript shootScript;
    private Coroutine cor;

    public void changeProjectile(GameObject projectile)
    {
        shootScript.projectile = projectile;
        if (cor != null)
        {
            StopCoroutine(cor);
            shootScript.CanReload = true;
        }
        cor = StartCoroutine(shootScript.ReloadProjectile(0f));
    }
}
