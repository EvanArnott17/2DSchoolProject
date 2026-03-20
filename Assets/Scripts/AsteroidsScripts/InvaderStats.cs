using UnityEngine;

[CreateAssetMenu(fileName = "InvaderStats", menuName = "Scriptable Objects/InvaderStats")]
public class InvaderStats : ScriptableObject
{
    public string AlienName;

    public float MoveSpeed;

    public float FireRate;

    public int ScoreValue;
}
