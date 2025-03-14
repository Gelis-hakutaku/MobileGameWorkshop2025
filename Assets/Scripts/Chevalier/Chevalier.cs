using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Chevalier : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private PlayerScore _playerScore;

    
    private BoxCollider _boxCollider;
    private SpriteRenderer _meshRender;

    private void Start()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
        _meshRender = this.GetComponentInChildren<SpriteRenderer>();
        _audioSource.clip = _clip;
        _playerScore.NbKnights += 1;
    }

    private void OnEnable()
    {
        _playerScore.OnAllKnightsDead += OnGameOver;
    }

    private void OnDisable()
    {
        _playerScore.OnAllKnightsDead -= OnGameOver;
    }

    private void OnGameOver()
    {

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
            StartCoroutine(WaitBeforeDeath());
            //Score??
            _playerScore.AddPoints(_playerScore.KnightPoint);
        }
    }

    IEnumerator WaitBeforeDeath()
    {
        yield return new WaitForSeconds(_clip.length);
        _playerScore.NbKnights -= 1;
        Destroy(gameObject);
    }
}

