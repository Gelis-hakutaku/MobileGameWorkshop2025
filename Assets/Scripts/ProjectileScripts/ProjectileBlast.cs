using UnityEngine;

public class ProjectileBlast : MonoBehaviour
{
    [SerializeField] private Collider Collider;

    [Header("BlastStats")]
    [SerializeField] private float blastRadius = 5f;
    [SerializeField] private float blastForce = 700f;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, blastRadius))
        {
            if (hit.GetComponent<Rigidbody>() && hit != this.gameObject)
            {
                hit.GetComponent<Rigidbody>().AddForce((hit.transform.position - transform.position) * blastForce);
            }
        }
        Destroy(this.gameObject);
    }
}
