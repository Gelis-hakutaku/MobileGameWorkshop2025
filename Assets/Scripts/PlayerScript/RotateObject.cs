using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float slerpSpeed = 5f;
  
    public bool canTurn = true;

    private float rotationY;
    private Quaternion targetRotation;

    //donne la force de rotation � l'objet en fonction du mouvement du doigt
    public void OnSwipe(InputAction.CallbackContext ctxt)
    {
        if (!canTurn) return;
        float deltaX = ctxt.ReadValue<Vector2>().x;
        rotationY += deltaX * rotationSpeed * Time.deltaTime;
        targetRotation = Quaternion.Euler(0, rotationY, 0);
    }

    //fait tourner l'objet avec une l�g�re inertie
    private void Update()
    {
        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime);     
        }
    }
}
