using UnityEngine;

public class ProximitySensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FleetManager fleetManager = GetComponentInParent<FleetManager>();
            if(fleetManager != null)
            {
                fleetManager.SoundAlarm();
            }
        }
    }
}
