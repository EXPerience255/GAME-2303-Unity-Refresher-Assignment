using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float HealthMax { get; set; }
}
