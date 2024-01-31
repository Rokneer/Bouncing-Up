using UnityEngine;

public class UpdateSpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;
    private TeleportToIsland respawn;

    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("DeathPlane").GetComponent<TeleportToIsland>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
            respawn.respawnPoint = spawnPoint;
    }
}
