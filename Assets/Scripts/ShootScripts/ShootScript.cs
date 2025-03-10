using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _projBaseCoord;
    private Vector3 _screenPos;
    private Vector3 _worldPos;
    private float _mltp=(10.0f);
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _viseur;
    private Rigidbody rb;
    [SerializeField] private float _force;
    private Vector3 _direction;
    private Vector3 _directionNormal;
    private Vector3 _velocity;
    private float _temps;

    void Start()
    {
        _projBaseCoord = new Vector3(0, -1, 0);
        rb = GetComponent<Rigidbody>();
    }

    /*Vector3 Trajectoire(float t)
    {
        _velocity = _direction * _force;
    }*/


    public void MoveBall()
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        _worldPos.z = _projBaseCoord.z + ((_input.y / Screen.height)*_mltp)-_offset;
        transform.position = _worldPos;
    }

    public void OnClicked(InputAction.CallbackContext ctxt)
    {
        rb.linearVelocity = new Vector3(0f, 0f, 0f);
        rb.useGravity = false;

        _input = (ctxt.ReadValue<Vector2>());

        if (_input == new Vector2(0.0f, 0.0f))
        {
            rb.useGravity = true;
            _direction = _viseur.transform.position - transform.position;
            _directionNormal = _direction.normalized;
            rb.AddForce(_directionNormal * _force);
        }
    }

    void Update()
    {
        if (_input != new Vector2(0.0f, 0.0f))
        {
            MoveBall();
        }
    }
}
