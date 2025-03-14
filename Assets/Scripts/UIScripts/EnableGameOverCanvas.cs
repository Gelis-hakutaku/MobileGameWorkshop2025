using System.Collections;
using UnityEngine;

public class EnableGameOverCanvas : MonoBehaviour
{

    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private GameObject _gameplayCanvas;
    [SerializeField] private GameObject _endGameCanvas;
    private void OnEnable()
    {
        _playerScore.OnAllKnightsDead += OnGameOver;
    }

    private void OnDisable()
    {
        _playerScore.OnAllKnightsDead -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void OnGameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(WaitBeforeEnd());        
    }

    IEnumerator WaitBeforeEnd()
    {
        yield return new WaitForSeconds(3f);
        _gameplayCanvas.SetActive(false);
        _endGameCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
