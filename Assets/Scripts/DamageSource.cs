using System.Collections;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] Stats myStats;
    [SerializeField] float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Damage");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine("Damage");
        }
    }

    private IEnumerator Damage()
    {
        while (true)
        {
            myStats.Health -= damage;
            yield return new WaitForSeconds(2);
        }
    }
}