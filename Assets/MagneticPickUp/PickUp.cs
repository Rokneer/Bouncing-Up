using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
            Destroy(gameObject);
    }
}
