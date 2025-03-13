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
    public GameObject projectile;

    [Header ("Force")]
    [SerializeField] private float maxForce = 1;
    [SerializeField] private float minForce = .1f;
    [SerializeField] private float upwardOffset = 0.5f;
    private float _force;

    [Header("DeadZone")]
    [SerializeField] private float maxZone = .4f;
    [SerializeField] private float minZone = .05f;

    private Vector3 spawnPosition;
    private Transform childProjectile;
    private Trajectory trajectoryScript;

    private Vector3 initLocalPosition;
    private bool canAim;
    private bool canShoot = true;
    private bool canReload = true;

    private float _mltp=(10.0f);
    private Vector2 _input;
    private Vector3 _screenPos;
    private Vector3 _worldPos;
    private Rigidbody rb;
    private Vector3 _direction;
    private Vector3 _directionNormal;
    private Vector3 _velocity;
    private float _distance;
    private float _temps;

    void Start()
    {
        initLocalPosition = transform.localPosition;

        trajectoryScript = GetComponent<Trajectory>();

        AssignProjectile();

        rb.useGravity = false;
    }

    public void SpawnNewProjectile()
    {
        Instantiate(projectile, spawnPosition, Quaternion.identity, transform);
        AssignProjectile();
    }

    public void AssignProjectile()
    {
        childProjectile = transform.GetChild(0);
        rb = childProjectile.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void MoveBall()
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);

        float pullValue = Mathf.Clamp(Mathf.InverseLerp(maxZone, minZone, _input.y / Screen.height), 0, 1);

        float distance = Mathf.Lerp(6, 2.72f, pullValue);
        float height = Mathf.Lerp(0, 1.15f, pullValue);
        _force = Mathf.Lerp(minForce, maxForce, pullValue);


        transform.localPosition = new Vector3(_input.x / Screen.width -.5f,
                                        initLocalPosition.y - height,
                                        distance);
    }

    public void OnHold(InputAction.CallbackContext ctxt)
    {
        _input = (ctxt.ReadValue<Vector2>());

        if (ctxt.started)
        {
            if (!clickOnBullet() || !canShoot)
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

            if(Vector3.Distance(initLocalPosition, transform.localPosition) < .4f)
            {
                transform.localPosition = initLocalPosition;
                return;
            }

            Shoot();
            StartCoroutine(ReloadProjectile(2f));
        }
    }

    bool clickOnBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(_input);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {
            // Si l'objet touché a le tag "Player", on retourne true
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Touchéé!");
                return true;
            }
            else return false;
        }

        return false;
    }


    void Shoot()
    {
        rb.useGravity = true;

        rb.AddForce(_directionNormal * _force * _distance, ForceMode.Impulse);

        childProjectile.parent = null;
        rb = null;
        childProjectile = null;

        transform.localPosition = initLocalPosition;
        return;
    }

    public IEnumerator ReloadProjectile(float reloadTime)
    {
        if (!canReload) yield return null;
        else
        {
            canReload = false;
            if (childProjectile != null) Destroy(childProjectile.gameObject);

            canShoot = false;

            yield return new WaitForSeconds(reloadTime);

            SpawnNewProjectile();

            float duration = 1f;
            float elapsed = 0f;

            Vector3 posA = new Vector3(0f, -3f, 1f);
            Vector3 posB = new Vector3(0f, -1f, 0f);
            while (elapsed < duration)
            {
                float easedT = 1 - Mathf.Pow(1 - elapsed / duration, 3);

                childProjectile.transform.localPosition = Vector3.Lerp(posA, posB, easedT);

                elapsed += Time.deltaTime;
                yield return null;
            }

            childProjectile.transform.localPosition = posB;

            canShoot = true;
            canReload = true;
        }
    }


    void CalculateForceAndDirection()
    {
        _distance = Vector3.Distance(initLocalPosition, childProjectile.localPosition) * 30;
        Vector3 localDirection = initLocalPosition - transform.localPosition;
        _direction = transform.TransformDirection(localDirection);
        _direction.y += upwardOffset;
        _directionNormal = _direction.normalized;
    }


    void Update()
    {
        if (_input != new Vector2(0.0f, 0.0f) && canAim)
        {
            MoveBall();
            CalculateForceAndDirection();

            if (Vector3.Distance(initLocalPosition, transform.localPosition) < .4f)
            {
                trajectoryScript.HideTrajectory();
                return;
            } 
            trajectoryScript.DrawTrajectory(_force, _directionNormal, _distance, rb.mass);
        }
        else trajectoryScript.HideTrajectory();
    }
}

