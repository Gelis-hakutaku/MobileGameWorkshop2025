using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float slerpSpeed = 5f;
  

    private float rotationY;
    private Quaternion targetRotation;

    //vérifie que l'écran est bien touché
    public void OnTouch()
    {
        Debug.Log("Touch");
    }

    //donne la force de rotation à l'objet en fonction du mouvement du doigt
    public void OnSwipe()
    {
        float deltaX = Touchscreen.current.primaryTouch.delta.x.value;
        rotationY += deltaX * rotationSpeed * Time.deltaTime;
        targetRotation = Quaternion.Euler(0, rotationY, 0);
    }

    //fait tourner l'objet avec une légère inertie
    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime); //peut potentiellment être lourd, à surveiller
    }
}
