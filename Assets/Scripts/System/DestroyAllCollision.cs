using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyAllCollision : MonoBehaviour
{
    [SerializeField] private Collider _collider; //Le collider doit être set en trigger
    [SerializeField] private PlayerScore _playerScore;

    private void OnTriggerEnter(Collider other)
    {
        //script à éditer quand les objets de score seront créés
        /*if (other.TryGetComponent<insérerClasseDeLaMortDesEnnemis>(out classe object))
          {
                Object.FonctionDeScore();
                _playerScore.Score += valeurDeScore;
          }
        */
        Destroy(other.gameObject);
    }
}
