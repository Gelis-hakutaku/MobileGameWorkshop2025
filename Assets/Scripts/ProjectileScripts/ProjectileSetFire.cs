using UnityEngine;

public class ProjectileSetFire : MonoBehaviour
{
    [SerializeField] private Material burningMat;
    [SerializeField] private ParticleSystem burningParticles;
    private int initParticleNumber = 400;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Flammable"))
        {
            col.gameObject.GetComponent<MeshRenderer>().material = burningMat;

            ParticleSystem particles = Instantiate(burningParticles, col.transform.position, Quaternion.identity, col.transform);

            initParticleNumber = Mathf.Round(initParticleNumber * ((col.transform.lossyScale.x + col.transform.lossyScale.y + col.transform.lossyScale.z) / 3));

            var shape = particles.shape; 
            shape.scale = col.transform.lossyScale;
            shape.rotation = col.transform.rotation.eulerAngles;
            shape.mesh = col.gameObject.GetComponent<MeshFilter>().mesh;
        }
        Destroy(this.gameObject);
    }
}
