using UnityEngine;

//CE SCRIPT SERT DE D�BUG ACTUELLEMENT ET DOIT �TRE MODIFI�
public class BurningScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer mRenderer;
    public void Burn()
    {
        mRenderer.material.color = Color.red;
    }
}
