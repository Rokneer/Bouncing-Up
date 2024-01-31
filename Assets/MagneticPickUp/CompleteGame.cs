using UnityEngine;

public class CompleteGame : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<Magnetisim>().enabled = false;
        }
    }
}
