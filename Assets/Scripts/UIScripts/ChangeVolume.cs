using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat("Volume", _slider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
