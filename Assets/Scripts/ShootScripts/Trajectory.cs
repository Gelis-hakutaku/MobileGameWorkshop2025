using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private GameObject prefabObj; //Trajectoire
    [SerializeField] private int _trajectorySteps = 30;
    [SerializeField] private float _timeStep = 0.1f;

    private List<GameObject> _trajectoryPoints = new List<GameObject>();

    void Start()
    {
        for (int i = _trajectorySteps; i >= 0; i--)
        {
            GameObject point = Instantiate(prefabObj, transform.position, Quaternion.identity);

            float size = Mathf.Lerp(.3f, 1f, (1f / _trajectorySteps * i));
            point.transform.localScale = new Vector3(size, size, size);

            point.SetActive(false);
            _trajectoryPoints.Add(point);
        }

    }

    public void HideTrajectory() // Fais dispraître les points
    {
        foreach (var point in _trajectoryPoints)
        {
            point.SetActive(false);
        }
    }

    public Vector3 CalculateTrajectory(float time, float force, Vector3 _directionNormal, float distance, float mass) // Calcul la trajectoire
    {
        Vector3 gravity = Physics.gravity;
        Vector3 velocity = _directionNormal * (force * distance) / mass;
        return transform.position + velocity * time + 0.5f * gravity * time * time; // Formule
    }

    public void DrawTrajectory(float force, Vector3 _directionNormal, float distance, float mass) // Dessine la trajectoire
    {
        for (int i = 0; i <= _trajectorySteps; i++)
        {
            float time = i * _timeStep;
            Vector3 point = CalculateTrajectory(time, force, _directionNormal, distance, mass);
            // Instantiate(prefabObj, point, Quaternion.identity);

            _trajectoryPoints[i].transform.position = point;
            _trajectoryPoints[i].SetActive(true);
        }
    }
}
