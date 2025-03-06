using UnityEngine;
using System.Collections;

public class SetListenerVolume : MonoBehaviour
{

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
