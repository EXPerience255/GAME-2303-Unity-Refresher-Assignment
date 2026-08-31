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
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1f, floorLayerMask))
            anim.SetBool("isGrounded", true);
        else
            anim.SetBool("isGrounded", false);

        Vector3 correctedInput = GetCameraBasedInput(moveVector, Camera.main);
        rb.AddForce(correctedInput * moveSpeed, ForceMode.Acceleration);
        anim.transform.forward = correctedInput;
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

    public Vector3 GetCameraBasedInput(Vector2 input, Camera camera)
    {
        Vector3 camRight = camera.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        return (input.x * camRight) + (input.y * camForward);
    }
}
