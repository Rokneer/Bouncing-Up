using UnityEngine;

public class HookeLaw : MonoBehaviour
{
    public float elasticConstant;
    public float naturalLength;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ApplyRestorativeForce(collision.gameObject);
    }
    private void ApplyRestorativeForce(GameObject fallingObject)
    {
        if (!fallingObject.TryGetComponent<Rigidbody>(out Rigidbody rb)) return;

        // Calculate relative position
        float relativePos = fallingObject.transform.position.y - transform.position.y;
        // Calculate elastic force
        float elasticForce = elasticConstant * (relativePos - naturalLength);
        // Apply force
        rb.AddForce(Vector3.up * elasticForce, ForceMode.Impulse);
    }
}
