using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;

    public void OnButtonClick(string scene)
    {
        StartCoroutine(AsyncLoading(_sceneToLoad)); //cette coroutine permet de charger la scène sans bloquer le jeu
    }

    private IEnumerator AsyncLoading(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
            _sceneToLoad = SceneManager.GetActiveScene().name; //si le nom de la scène est vide, on recharge la scène actuelle
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(sceneName); //on lance le chargement et on stocke l'opération dans une variable

        //tant que le chargement n'est pas terminé, on attend
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }
    }
}
