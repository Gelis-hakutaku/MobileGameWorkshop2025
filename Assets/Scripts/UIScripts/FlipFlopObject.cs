using UnityEngine;

public class FlipFlopObject : MonoBehaviour
{
    private bool _isActive = false;

    public void FlipFlop(GameObject objectToLoad)
    {
        _isActive = !_isActive;
        objectToLoad.SetActive(_isActive);
    }
}
