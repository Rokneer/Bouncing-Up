using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce,
        jumpCooldown,
        airMultipler;
    private bool isReadyToJump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    private bool isGrounded;

    public Transform orientation;
    private float horizontalInput,
        verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isReadyToJump = true;
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            playerHeight * 0.5f + 0.3f,
            groundLayer
        );

        GetPlayerInput();
        SpeedControl();

        // Handle applying drag
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && isReadyToJump && isGrounded)
        {
            isReadyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
            rb.AddForce(10f * moveSpeed * moveDirection.normalized, ForceMode.Force);
        else
            rb.AddForce(10f * airMultipler * moveSpeed * moveDirection.normalized, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new(rb.velocity.x, 0f, rb.velocity.z);
        // Caps velocity to a maximum
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        isReadyToJump = true;
    }
}
