using UnityEngine;

public class ProjectileSetFire : MonoBehaviour
{

    private AudioSource audioS;
    [SerializeField] private AudioClip fire;

    [SerializeField] private Material burningMat;
    [SerializeField] private ParticleSystem burningParticles;
    private int initParticleNumber = 400;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Flammable"))
        {
            col.gameObject.GetComponent<MeshRenderer>().material = burningMat;

            ParticleSystem particles = Instantiate(burningParticles, col.transform.position, Quaternion.identity, col.transform);

            initParticleNumber = Mathf.RoundToInt(initParticleNumber * ((col.transform.lossyScale.x + col.transform.lossyScale.y + col.transform.lossyScale.z) / 3));

            var shape = particles.shape; 
            var emission = particles.emission;

            emission.rateOverTime = initParticleNumber;

            shape.rotation = col.transform.rotation.eulerAngles;
            shape.mesh = col.gameObject.GetComponent<MeshFilter>().mesh;

            col.gameObject.AddComponent<BurningScript>();
        }

        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        transform.GetChild(0).parent = null;

        audioS.PlayOneShot(fire);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        Destroy(this.gameObject, 3f);
    }
}
