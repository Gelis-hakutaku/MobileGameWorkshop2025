using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    public void SavePlayerData()
    {
        JsonUtility.ToJson(_playerScore.Highscores);
    }
}
