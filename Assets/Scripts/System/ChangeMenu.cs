using UnityEngine;

public class ChangeMenu : MonoBehaviour
{
    public void GoToMenu(GameObject targetCanvas)
    {
        targetCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
