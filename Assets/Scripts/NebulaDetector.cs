using UnityEngine;

public class NebulaDetector : MonoBehaviour
{
    [SerializeField] private float _slowdownSpeed;

    [SerializeField] private ShipMovement _ship;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            
        }
    }
}
