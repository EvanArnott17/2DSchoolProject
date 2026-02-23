using UnityEngine;

public class Death_Zone : MonoBehaviour
{
    [SerializeField] private Vector2 respawnPoint;

    [SerializeField] private GameObject pinball;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() == true)
        {
            Debug.Log("Player Dead");
            collision.gameObject.SetActive(false);

            Invoke("RespawnPinball", 0.5f);
        }
    }

    private void RespawnPinball()
    {
        pinball.transform.position = respawnPoint;
        pinball.SetActive(true);
    }

    
}
