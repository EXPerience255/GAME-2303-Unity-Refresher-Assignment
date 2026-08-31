using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform gateL;
    [SerializeField] private Transform gateR;
    [SerializeField] private float openLength;
    [SerializeField] private float openSpeed;
    [SerializeField] private float closeSpeed;
    private Vector3 gateLPos;
    private Vector3 gateRPos;
    private bool isOpen;

    private void Start()
    {
        gateLPos = gateL.position;
        gateRPos = gateR.position;
    }

    private void Update()
    {
        if (isOpen)
        {
            gateL.position = Vector3.Lerp(gateL.position, gateLPos - (transform.right * openLength * transform.localScale.x), Time.deltaTime * openSpeed);
            gateR.position = Vector3.Lerp(gateR.position, gateRPos + (transform.right * openLength * transform.localScale.x), Time.deltaTime * openSpeed);
        }
        else
        {
            gateL.position = Vector3.Lerp(gateL.position, gateLPos, Time.deltaTime * closeSpeed);
            gateR.position = Vector3.Lerp(gateR.position, gateRPos, Time.deltaTime * closeSpeed);
        }
    }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }
}
