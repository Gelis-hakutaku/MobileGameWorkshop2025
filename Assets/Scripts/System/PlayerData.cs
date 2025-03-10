using UnityEngine;
using System;

//Ce script sert � convertir les donn�es de PlayerScore en donn�es s�rialis�es pour les sauvegarder dans un json

[Serializable]
public class PlayerData
{
    private int[] _highscores;
    private bool[] isLevelLocked;

    public int[] Highscores
    {
        get => _highscores;
        set => _highscores = value;
    }

    public bool[] IsLevelLocked
    {
        get => isLevelLocked;
        set => isLevelLocked = value;
    }
}
