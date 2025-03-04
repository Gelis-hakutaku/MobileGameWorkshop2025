using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float slerpSpeed = 5f;      
    private float rotationY;
    private Vector2 lastTouchPosition;
    private bool isDragging = false;

    void Update()
    {
        float test = Touchscreen.current.primaryTouch.delta.x;
        if (Touchscreen.current.primaryTouch.delta.x)
        {
            float deltaX = touch.position.x - lastTouchPosition.x;
            rotationY -= deltaX * rotationSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.Euler(0, rotationY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slerpSpeed * Time.deltaTime);

            lastTouchPosition = touch.position;
        }
    }
}
