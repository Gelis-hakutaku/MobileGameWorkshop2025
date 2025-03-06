using UnityEngine;

public class UpdatePause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private bool isPaused = false;

    public void OnPause()
    {
        isPaused = !isPaused;
        _pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; //passe la valeur du temps à 0 si isPaused est vrai, sinon la remet à 1
    }
}
