using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
