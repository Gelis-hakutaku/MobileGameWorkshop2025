using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "Scriptable Objects/PlayerScore")]
public class PlayerScore : ScriptableObject
{
    [Header ("Level Management")]
    [SerializeField] int _maxLevel;

    [Header("Points")]
    [SerializeField] int _blockPoints;
    [SerializeField] int _knightPoint;

    private int _nbKnights;
    private int _score;
    private int[] _highscores;
    private bool[] _isLevelLocked;

    public event Action OnAllKnightsDead;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public int NbKnights
    {
        get => _nbKnights;
        set 
        { 
            _nbKnights = value;
            Debug.Log(value);
            if (NbKnights <= 0)
            {
                OnAllKnightsDead?.Invoke();
            }
        }
    }

    public int[] Highscores
    {
        get => _highscores;
        set => _highscores = value;
    }

    public int BlockPoints
    {
        get => _blockPoints;
        set => _blockPoints = value;
    }

    public int KnightPoint
    {
        get => _knightPoint;
        set => _knightPoint = value;
    }
    public bool[] IsLevelLocked
    {
        get => _isLevelLocked;
        set => _isLevelLocked = value;
    }

    public void Initialize()
    {
        _maxLevel = SceneManager.sceneCountInBuildSettings - 1;
        _score = 0;
        _highscores = new int[_maxLevel];
        _isLevelLocked = new bool[_maxLevel];
    }

    public void ResetScore()
    {
        _score = 0;
        _nbKnights = 0;
    }

    public void AddPoints(int value)
    {
        Score += value;
        Debug.Log(Score);
    }



    public void SetHighscore(int currentLevel)
    {
        if (_score > _highscores[currentLevel])
        {
            _highscores[currentLevel] = _score;
        }
    }
}
