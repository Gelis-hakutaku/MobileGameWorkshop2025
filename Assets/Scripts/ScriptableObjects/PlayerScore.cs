using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "Scriptable Objects/PlayerScore")]
public class PlayerScore : ScriptableObject
{
    [SerializeField] private int _score;

    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
