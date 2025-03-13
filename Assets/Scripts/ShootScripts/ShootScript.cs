using UnityEngine;
using UnityEngine.InputSystem;
using System.Reflection;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using System.Collections;

public class ShootScript : MonoBehaviour
{
    [Header("ProjectileRelated")]
    [SerializeField] private GameObject projectile;    
    [SerializeField] private float reloadTime;    

    [Header ("Force")]
    [SerializeField] private float _force = 150;
    [SerializeField] private float upwardOffset = 0.5f;

    [Header("DeadZone")]
    [SerializeField] private float maxZone = .38f;
    [SerializeField] private float minZone = .05f;

    private Transform childProjectile;

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

        AssignProjectile();

        rb.useGravity = false;
    }

    public void SpawnNewProjectile()
    {
        AssignProjectile();
    }

    public void AssignProjectile()
    {
        childProjectile = transform.GetChild(0);
        rb = childProjectile.GetComponent<Rigidbody>();
    }

    public void MoveBall()
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);

        float pullValue = Mathf.Clamp(Mathf.InverseLerp(maxZone, minZone, _input.y / Screen.height), 0, 1);
        Debug.Log(pullValue);

        float distance = Mathf.Lerp(6, 2.72f, pullValue);
        float height = Mathf.Lerp(0, 1.15f, pullValue);


        transform.localPosition = new Vector3(_input.x / Screen.width -.5f,
                                        initLocalPosition.y - height,
                                        distance);
    }

    public void OnHold(InputAction.CallbackContext ctxt)
    {
        _input = (ctxt.ReadValue<Vector2>());

        if (ctxt.started)
        {
            if ((_input.y / Screen.height) > maxZone)
            {
                canAim = false;
                return;
            }
            else canAim = true;

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

            Shoot();
            StartCoroutine(ShootDelay());
        }
    }

    void Shoot()
    {
        rb.useGravity = true;
        _direction = initLocalPosition - transform.localPosition;
        _direction.y = _direction.y + upwardOffset;
        _directionNormal = _direction.normalized;

        float _distance = Vector3.Distance(initLocalPosition, childProjectile.localPosition) * 30;

        rb.AddForce(_directionNormal * _force * _distance, ForceMode.Impulse);

        childProjectile.parent = null;
        rb = null;
        childProjectile = null;

        transform.localPosition = initLocalPosition;
        return;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(reloadTime);
    }

    void Update()
    {
        if (_input != new Vector2(0.0f, 0.0f) && canAim)
        {
            MoveBall();
        }
    }
}
