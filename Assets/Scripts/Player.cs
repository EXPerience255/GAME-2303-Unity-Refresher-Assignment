using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveVector;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveVector.x, 0, moveVector.y) * moveSpeed, ForceMode.Acceleration);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        moveVector = dir;
    }
}
