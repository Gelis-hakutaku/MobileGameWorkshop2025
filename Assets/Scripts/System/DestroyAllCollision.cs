using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyAllCollision : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    private void OnTriggerEnter(Collider other)
    {
        //S'il s'agit d'un bloc ou d'un chevalier, on actualise le score
        if (other.gameObject.layer == 6)
          {
                _playerScore.AddPoints(_playerScore.BlockPoints);
          }
        Destroy(other.gameObject);

        if (other.CompareTag("Knight"))
        {
            _playerScore.NbKnights--;
            _playerScore.AddPoints(_playerScore.KnightPoint);
        }

    }
}
