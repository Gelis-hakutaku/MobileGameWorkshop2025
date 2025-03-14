using UnityEngine;
using UnityEngine.UI;

public class SetSelectedProjectile : MonoBehaviour
{
    [SerializeField] private RectTransform[] projectileButtons;

    public void SetSelected(RectTransform SelectedButton)
    {
        foreach (RectTransform projButton in projectileButtons)
        {
            projButton.GetComponent<Image>().color = new Color(.7f, .7f, .7f);
            projButton.localScale = new Vector3(1.9f, 1.9f, 1.9f);
        }

        SelectedButton.localScale = new Vector3(2.4f, 2.4f, 2.4f);
        SelectedButton.GetComponent<Image>().color = Color.white;
    }

    public void ShowButtons()
    {
        foreach (RectTransform projButton in projectileButtons)
        {
            projButton.gameObject.SetActive(true);
        }
    }

    public void HideButtons()
    {
        foreach (RectTransform projButton in projectileButtons)
        {
            projButton.gameObject.SetActive(false);
        }
    }
}
