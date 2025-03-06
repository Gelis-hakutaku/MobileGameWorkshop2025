using TMPro;
using UnityEngine;

public class PrintScore : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private TextMeshProUGUI _text;

    void OnUpdate()
    {
        _text.text = _playerScore.Score.ToString();
    }
}
