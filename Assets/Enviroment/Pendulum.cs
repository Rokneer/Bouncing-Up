using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("Parameters")]
    public float length;
    public float dampening = 0.99f;
    private float angle;
    private float angularVelocity;
    private Rigidbody rb;
    private readonly float gravity = 9.8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        angle = 45f;
        angularVelocity = 0f;
    }

    void Update()
    {
        // Calculate angular acceleration with the simple pendulum equation
        float angularAcceleration = (-gravity / length) * Mathf.Sin(angle);
        // Update angular velocity and angle using the Verlet method
        angularVelocity += angularAcceleration * Time.deltaTime;
        angle += angularVelocity * Time.deltaTime;
        // Apply position and rotation

        /* Vector3 newPosition = new(length * Mathf.Sin(angle), -length * Mathf.Cos(angle), 0f); */
        rb.velocity = new(length * Mathf.Sin(angle), -length * Mathf.Cos(angle), 0f);
        /* transform.SetPositionAndRotation(newPosition, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg)); */
        // Apply dampening to simulate air resistance
        angularVelocity *= dampening;
    }
}
