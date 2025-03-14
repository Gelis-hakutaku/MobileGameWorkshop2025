using UnityEngine;

public class RotateSpriteToCam : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _spriteTransform;

    void LateUpdate()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;

        cameraPosition.y = transform.position.y;

        _spriteTransform.LookAt(cameraPosition);

        _spriteTransform.Rotate(0f, 180f, 0f);

    }
}
