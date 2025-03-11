using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float maxPull = 5f;
    [SerializeField] private float minPull = 1f;

    private Vector3 initLocalPosition;
    private bool canAim;

    private float _mltp=(10.0f);
    private Vector2 _input;
    private Vector3 _screenPos;
    private Vector3 _worldPos;
    private Rigidbody rb;
    private Vector3 _direction;
    private Vector3 _directionNormal;
    private Vector3 _velocity;
    private float _temps;

    void Start()
    {
        initLocalPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void MoveBall()
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        float distance = Mathf.Clamp(_input.y / Screen.height * _mltp, minPull, maxPull);

        float invertDistance = (minPull + maxPull) - distance - 1;
        Debug.Log(invertDistance);

        transform.localPosition = new Vector3(_input.x / Screen.width -.5f,
                                        initLocalPosition.y - .15f * invertDistance, //Conversion de la hauteur. Local > World 
                                        distance);
    }

    public void OnHold(InputAction.CallbackContext ctxt)
    {
        _input = (ctxt.ReadValue<Vector2>());

        if (ctxt.started)
        {
            CheckZone();

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
        }

        if (ctxt.canceled)
        {
            if (!canAim) return;

            if(Vector3.Distance(initLocalPosition, transform.localPosition) < 1f)
            {
                transform.localPosition = initLocalPosition;
                return;
            }

            rb.useGravity = true;
            _direction = initLocalPosition - transform.localPosition;
            _directionNormal = _direction.normalized;

            float _distance = Vector3.Distance(initLocalPosition, transform.localPosition) * 50;

            rb.AddForce(_directionNormal * _force * _distance);
        }
    }

    void CheckZone()
    {
        if ((_input.y / Screen.height) > .34f)
        {
            canAim = false;
            return;
        }
        else canAim = true;
    }

    void Update()
    {
        if (_input != new Vector2(0.0f, 0.0f) && canAim)
        {
            MoveBall();
        }
    }
}
