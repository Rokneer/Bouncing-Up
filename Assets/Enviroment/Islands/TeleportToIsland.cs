using UnityEngine;

public class TeleportToIsland : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponentInParent<Rigidbody>().transform.position = respawnPoint.position;
        }
    }
}
