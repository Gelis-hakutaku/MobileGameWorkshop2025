using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileIndex", menuName = "Scriptable Objects/ProjectileIndex")]
public class ProjectileIndex : ScriptableObject
{
    private int _index;
    
    public int Index
    {
        get => _index; 
        set => _index = value;
    }

}
