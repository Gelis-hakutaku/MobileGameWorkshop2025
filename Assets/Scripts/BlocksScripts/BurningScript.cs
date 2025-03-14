using System.Collections;
using UnityEngine;


public class BurningScript : MonoBehaviour
{
    private PlayerScore _playerScore;

    float timeToburn = 5;

    public void Initialize(PlayerScore playerscore)
    {
        _playerScore = playerscore;
        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        yield return new WaitForSeconds(timeToburn);

        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        Vector3 childScale = transform.GetChild(0).transform.lossyScale;
        childScale = new Vector3(1f, 1f, 1f);
        transform.GetChild(0).parent = null;

        Camera.main.GetComponent<CameraShake>().ShakeCamera(.2f, .05f);

        _playerScore.AddPoints(_playerScore.BlockPoints);

        Destroy(gameObject);
    }
}
