using UnityEngine;

public class CallLoading : MonoBehaviour
{
    private void Start()
    {
        Object.FindAnyObjectByType<PlayerDataManager>().LoadPlayerData();
    }
}

