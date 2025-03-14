using UnityEngine;

public class ProjectileBlast : MonoBehaviour
{
    [SerializeField] private Collider Collider;
    [SerializeField] private GameObject explosionVFX;

    private AudioSource audioS;
    [SerializeField] private AudioClip explosion;

    [Header("BlastStats")]
    [SerializeField] private float blastRadius = 5f;
    [SerializeField] private float blastForce = 700f;

    [Header("CameraShake")]
    [SerializeField] private float cameraShakeDuration = .35f;
    [SerializeField] private float cameraShakeIntensity = .5f;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        //projette au loin tous les objets pris dans l'explosion sauf lui-même
        foreach (Collider hit in Physics.OverlapSphere(transform.position, blastRadius))
        {
            if (hit.TryGetComponent<Rigidbody>(out Rigidbody rb) && hit != gameObject)
            {
                rb.AddForce((hit.transform.position - transform.position) * blastForce); 
            }
        }

        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Camera.main.GetComponent<CameraShake>().ShakeCamera(cameraShakeDuration, cameraShakeIntensity);
        audioS.PlayOneShot(explosion);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        Destroy(gameObject, 3f);
    }
}
