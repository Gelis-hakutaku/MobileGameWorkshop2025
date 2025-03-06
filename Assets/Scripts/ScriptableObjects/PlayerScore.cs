using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "Scriptable Objects/PlayerScore")]
public class PlayerScore : ScriptableObject
{
    [SerializeField] int _maxLevel;

    private int _score;
    private int[] _highscores;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public int[] Highscores
    {
        get => _highscores;
        set => _highscores = value;
    }

    public void Initialize()
    {
        _maxLevel = SceneManager.sceneCountInBuildSettings - 1;
        _score = 0;
        _highscores = new int[_maxLevel];
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void SetHighscore(int currentLevel)
    {
        if (_score > _highscores[currentLevel])
        {
            _highscores[currentLevel] = _score;
        }
    }
}
