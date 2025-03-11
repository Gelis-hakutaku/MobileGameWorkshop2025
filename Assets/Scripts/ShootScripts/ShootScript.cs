using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private float _force;

    private float _mltp=(10.0f);
    private Vector2 _input;
    private Vector3 _projBaseCoord;
    private Vector3 _screenPos;
    private Vector3 _worldPos;
    private Rigidbody rb;
    private Vector3 _direction;
    private Vector3 _directionNormal;
    private Vector3 _velocity;
    private float _temps;

    private GameObject target;

    void Start()
    {
        _projBaseCoord = new Vector3(0, -1, 0);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void MoveBall()
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        _worldPos.z = _projBaseCoord.z + ((_input.y / Screen.height) * _mltp) - _offset;
        transform.position = _worldPos;
    }

    public void OnHold(InputAction.CallbackContext ctxt)
    {
        _input = (ctxt.ReadValue<Vector2>());

        if (ctxt.started)
        {
            MoveBall();

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;

            target = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), transform.position, Quaternion.identity, transform.parent);
            target.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        if (ctxt.canceled)
        {
            rb.useGravity = true;
            _direction = target.transform.position - transform.position;
            _directionNormal = _direction.normalized;

            float _distance = Vector3.Distance(target.transform.position, transform.position) * 50;

            rb.AddForce(_directionNormal * _force * _distance);

            Destroy(target);
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
