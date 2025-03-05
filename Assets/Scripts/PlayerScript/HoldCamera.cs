using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ce script attache la caméra à un objet désigné
public class HoldCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    private void LateUpdate()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
    }
}
