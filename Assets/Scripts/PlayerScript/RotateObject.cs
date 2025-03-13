using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float slerpSpeed = 5f;
  
    private bool canTurn = false;

    private float rotationY;
    private Quaternion targetRotation;

    public void checkTouchLocation(InputAction.CallbackContext ctxt)
    {
        
    }

    //donne la force de rotation à l'objet en fonction du mouvement du doigt
    public void OnSwipe(InputAction.CallbackContext ctxt)
    {       
        float deltaX = ctxt.ReadValue<Vector2>().x;
        rotationY += deltaX * rotationSpeed * Time.deltaTime;
        targetRotation = Quaternion.Euler(0, rotationY, 0);
    }

    //fait tourner l'objet avec une légère inertie
    private void Update()
    {

        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime);     
        }
    }
}
