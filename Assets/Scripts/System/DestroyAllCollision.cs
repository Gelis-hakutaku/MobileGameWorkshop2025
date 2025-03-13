using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyAllCollision : MonoBehaviour
{
    [SerializeField] private Collider _collider; //Le collider doit être set en trigger
    [SerializeField] private PlayerScore _playerScore;

    private void OnTriggerEnter(Collider other)
    {
        //S'il 
        if (other.gameObject.layer == 6)
          {
                _playerScore.AddPoints(_playerScore.BlockPoints);
          }
        Destroy(other.gameObject);
    }
}
