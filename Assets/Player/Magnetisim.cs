using UnityEngine;

public class Magnetisim : MonoBehaviour
{
    public float attractionForce;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("MagneticPickUp") && Input.GetKey(KeyCode.E))
        {
            // Checks if the pickup has a Rigidbody
            if (!collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                return;
            // Calculates the direction between the objects
            Vector3 direction = transform.position - collider.transform.position;
            // Calculates the attraction force
            float forceMagnitude = attractionForce / Mathf.Pow(direction.magnitude, 2);
            // Applies the force to the attracted pickup
            rb.AddForce(direction.normalized * forceMagnitude);
        }
    }
}
