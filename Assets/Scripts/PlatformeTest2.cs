using UnityEngine;

public class PlatformeTest2 : MonoBehaviour
{
    public float speed = 0;
    public int valeurs = 0;
    public GameObject[] PatrouillePoints;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PatrouillePoints[valeurs].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(PatrouillePoints[valeurs].transform.position, transform.position) < 0.1)
        {
            if (valeurs > 2)
            {
                valeurs = 0;
            }
            else
                valeurs++;
            Debug.Log(valeurs);
        }
    }
}