using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float slerpSpeed = 5f;
    

    private float rotationY;
    private Vector2 lastTouchPosition;

    //vérifie que l'écran est bien touché
    public void OnTouch()
    {
        Debug.Log("Touch");
    }

    //fait tourner l'objet en fonction du mouvement du doigt
    public void OnSwipe()
    {
         float deltaX = Touchscreen.current.primaryTouch.delta.x.value;
         rotationY += deltaX * rotationSpeed * Time.deltaTime;
         Quaternion targetRotation = Quaternion.Euler(0, rotationY, 0);
         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime);
    }
}
