using UnityEngine;

public class ChevalierCount : MonoBehaviour
{
    [SerializeField] public int _nbrChevalier;
    void Start()
    {
        
    }

    void Update()
    {
        if (_nbrChevalier <= 0)
        {
            Debug.Log("FIN DE PARTIE");
        }

        else
        {
            Debug.Log(_nbrChevalier);
        }
    }
}
