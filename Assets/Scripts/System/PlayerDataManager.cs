using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    private string Savepath => Application.persistentDataPath + "/playerData.json";
    private PlayerData _playerData;

    public void SavePlayerData()
    {
        // cr�ation de l'instance de PlayerData pour y stocker les donn�es du scriptable object
        PlayerData data = new PlayerData()
        {
            Highscores = _playerScore.Highscores,
            IsLevelLocked = _playerScore.IsLevelLocked
        };
        string json = JsonUtility.ToJson(_playerData); // conversion de l'instance en string pour le json
        File.WriteAllText(Savepath, json); // �criture du json
    }

    public void LoadPlayerData()
    {
        _playerScore.Initialize(); // lance la fonction du scriptable object pour initialiser ses tableaux
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(Savepath); //r�cup�re les donn�es du json et les stocke dans une instance de PlayerData

        // transfert des donn�es de PlayerData vers le scriptable object
        _playerScore.Highscores = playerData.Highscores;
        _playerScore.IsLevelLocked = playerData.IsLevelLocked;
    }
}
