using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float slerpSpeed = 5f;
  
    private bool canTurn;

    private float rotationY;
    private Quaternion targetRotation;

    public void OnTouch(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started)
        {
            if (ctxt.ReadValue<Vector2>().y / Screen.height < .38f) canTurn = false;
            else canTurn = true;
        }
    }

    //donne la force de rotation à l'objet en fonction du mouvement du doigt
    public void OnSwipe()
    {
        if (!canTurn) return;
        float deltaX = Touchscreen.current.primaryTouch.delta.x.value;
        rotationY += deltaX * rotationSpeed * Time.deltaTime;
        targetRotation = Quaternion.Euler(0, rotationY, 0);
    }

    //fait tourner l'objet avec une légère inertie
    private void Update()
    {
        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime); //peut potentiellment être lourd, à surveiller     
        }
    }
}
