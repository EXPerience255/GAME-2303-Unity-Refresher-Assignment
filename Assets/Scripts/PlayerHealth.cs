using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Stats myStats;
    [SerializeField] float maxHealth;

    private void Start()
    {
        myStats.Health = myStats.HealthMax;
    }
}
