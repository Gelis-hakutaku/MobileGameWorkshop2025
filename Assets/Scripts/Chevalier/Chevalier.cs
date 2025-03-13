using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Chevalier : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _chevalierCount;

    private ChevalierCount _chevalierCountScript;
    private BoxCollider _boxCollider;
    private SpriteRenderer _meshRender;

    private void Start()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
        _meshRender = this.GetComponent<SpriteRenderer>();
        _chevalierCountScript = _chevalierCount.GetComponent<ChevalierCount>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 7)
        {
            //Death
            _boxCollider.enabled = false;
            _meshRender.enabled = false;
            _audioSource.Play();
            _particleSystem.Play();
            //Score??
            _chevalierCountScript._nbrChevalier--;
        }
    }
}

