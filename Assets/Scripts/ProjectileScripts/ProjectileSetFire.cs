using UnityEngine;

public class ProjectileSetFire : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flammable"))
        {
            collision.gameObject.GetComponent<BurningScript>().Burn(); //appelle la fonction Burn() du script BurningScript si l'objet touché est inflammable
        }
        Destroy(this.gameObject);
    }
}
