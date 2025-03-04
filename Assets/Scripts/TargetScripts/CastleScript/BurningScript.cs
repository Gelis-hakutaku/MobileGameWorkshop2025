using UnityEngine;

//CE SCRIPT SERT DE DÉBUG ACTUELLEMENT ET DOIT ÊTRE MODIFIÉ
public class BurningScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer mRenderer;
    public void Burn()
    {
        mRenderer.material.color = Color.red;
    }
}
