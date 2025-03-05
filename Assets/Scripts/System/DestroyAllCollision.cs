using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyAllCollision : MonoBehaviour
{
    [SerializeField] private Collider _collider; //Le collider doit être set en trigger

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
