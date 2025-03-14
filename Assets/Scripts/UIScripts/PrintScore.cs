using TMPro;
using UnityEngine;

public class PrintScore : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private TextMeshProUGUI _text;

    void OnEnable()
    {
        _text.text = _playerScore.Score.ToString();
    }
}
