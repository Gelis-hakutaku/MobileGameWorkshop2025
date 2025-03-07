using System.Collections;
using UnityEngine;


public class BurningScript : MonoBehaviour
{
    float timeToburn = 5;

    private void Start()
    {
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        yield return new WaitForSeconds(timeToburn);

        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        transform.GetChild(0).parent = null;

        Camera.main.GetComponent<CameraShake>().ShakeCamera(.2f, .05f);

        Destroy(gameObject);
    }
}
