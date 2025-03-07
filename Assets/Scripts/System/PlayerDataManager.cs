using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    public void SavePlayerData()
    {
        JsonUtility.ToJson(_playerScore.Highscores);
    }

    public void LoadPlayerData()
    {
        _playerScore.Initialize();
        JsonUtility.FromJson<int>(_playerScore.Highscores.ToString());
    }
}
