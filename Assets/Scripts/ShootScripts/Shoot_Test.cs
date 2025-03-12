using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot_Test: MonoBehaviour
{
    private Vector2 _input; // Input
    private Vector3 _projBaseCoord; // CoordDuProj

    private Vector3 _screenPos;
    private Vector3 _worldPos;
    private float _mltp=(10.0f);
    [SerializeField] private float _offset;

    [SerializeField] private GameObject _viseur; //Viseur
    [SerializeField] private GameObject _prefabTraj; //Trajectoire

    private Rigidbody rb; //Rigidbody
    [SerializeField] private float _force; //Force de lancer

    private Vector3 _direction; //vecteur de direction entre le viseur et la balle
    private Vector3 _directionNormal;
    private float _distance; //Distance entre la balle et le viseur

    [SerializeField] private int _trajectorySteps = 30;
    [SerializeField] private float _timeStep = 0.1f;

    private List<GameObject> _trajectoryPoints = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < _trajectorySteps; i++)
        {
            GameObject point = Instantiate(_prefabTraj, transform.position, Quaternion.identity);
            point.SetActive(false); // On les désactive au début
            _trajectoryPoints.Add(point);
        }

        _projBaseCoord = new Vector3(0, -1, 0); //Position de la balle au départ
        rb = GetComponent<Rigidbody>();
    }

    void HideTrajectory()// Fais dispraître les points
    {
        foreach (var point in _trajectoryPoints)
        {
            point.SetActive(false);
        }
    }

    public void MoveBall() // Bouge la balle vers le curseur
    {
        _screenPos = new Vector3(_input.x, _input.y, 5);
        _worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
        _worldPos.z = _projBaseCoord.z + ((_input.y / Screen.height)*_mltp)-_offset;
        transform.position = _worldPos;
    }

    public void OnClicked(InputAction.CallbackContext ctxt)
    {
        _input = (ctxt.ReadValue<Vector2>()); // Lis l'input
        rb.linearVelocity = new Vector3(0f, 0f, 0f);
        rb.useGravity = false;
        _distance = (Vector3.Distance(_viseur.transform.position, transform.position)) * 2; //Calcul la distance entre le viseur et la balle

        _direction = _viseur.transform.position - transform.position; // Calcul la direction entre le viseur et la balle
        _directionNormal = _direction.normalized;

        DrawTrajectory(_trajectorySteps, _timeStep);

        if (ctxt.canceled)
        {
            rb.useGravity = true;
            rb.AddForce(_directionNormal * (_force * _distance), ForceMode.Impulse); // projete la balle
        }
    }

    public Vector3 CalculateTrajectory(float time) // Calcul la trajectoire
    {
        Vector3 gravity = Physics.gravity;
        Vector3 velocity = _directionNormal * (_force * _distance) / rb.mass;
        return transform.position + velocity * time + 0.5f * gravity * time * time; // Formule
    }

    void DrawTrajectory(int steps, float timeStep) // Dessine la trajectoire (steps, distance entre les steps)
    {

        for (int i = 0; i < steps; i++)
        {
            float time = i * timeStep;
            Vector3 point = CalculateTrajectory(time);
            //Instantiate(_prefabTraj, point, Quaternion.identity);

            _trajectoryPoints[i].transform.position = point;
            _trajectoryPoints[i].SetActive(true);
        }
    }


    void Update()
    {
        if (_input != new Vector2(0.0f, 0.0f))
        {
            MoveBall();
        }

        else 
        {
            HideTrajectory();
        }
    }
}
