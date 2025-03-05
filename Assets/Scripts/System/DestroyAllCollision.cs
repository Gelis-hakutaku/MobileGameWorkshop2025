using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyAllCollision : MonoBehaviour
{
    [SerializeField] private Collider _collider; //Le collider doit �tre set en trigger
    [SerializeField] private PlayerScore _playerScore;

    private void OnTriggerEnter(Collider other)
    {
        //script � �diter quand les objets de score seront cr��s
        /*if (other.TryGetComponent<ins�rerClasseDeLaMortDesEnnemis>(out classe object))
          {
                Object.FonctionDeScore();
                _playerScore.Score += valeurDeScore;
          }
        */
        Destroy(other.gameObject);
    }
}
