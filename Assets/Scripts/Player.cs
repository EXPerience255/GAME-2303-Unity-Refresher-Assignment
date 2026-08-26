using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private Vector2 moveVector;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask floorLayerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("moveSpeed", moveVector.magnitude);
        transform.forward = new Vector3(moveVector.x, 0, moveVector.y);
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveVector.x, 0, moveVector.y) * moveSpeed, ForceMode.Acceleration);
        if (Physics.Raycast(transform.position, Vector3.down, 1f, floorLayerMask))
            anim.SetBool("isGrounded", true);
        else
            anim.SetBool("isGrounded", false);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        moveVector = dir;
    }
}
