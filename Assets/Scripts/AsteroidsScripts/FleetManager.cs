using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] private float _shootTimer;
    private float _timer = 3f;
    public void SoundAlarm()
    {
        Debug.Log("Enemy Sighted");
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if(_shootTimer >= _timer)
        {
            FireAway();
            _shootTimer = 0;
        }
    }

    private void FireAway()
    {
        InvaderShoot[] allInvaders = GetComponentsInChildren<InvaderShoot>();

        foreach(InvaderShoot ship in allInvaders)
        {
            ship.FireLaser();
        }
    }
}
