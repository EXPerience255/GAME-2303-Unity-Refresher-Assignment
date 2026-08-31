using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent onEnteredEvent; public UnityEvent onExitedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onEnteredEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onExitedEvent.Invoke();
        }
    }
}
