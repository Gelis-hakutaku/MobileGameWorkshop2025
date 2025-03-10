using UnityEngine;

public class CallSaving : MonoBehaviour
{
    private void Start()
    {
        Object.FindAnyObjectByType<PlayerDataManager>().SavePlayerData();
        Debug.Log(Application.persistentDataPath);
    }
}

