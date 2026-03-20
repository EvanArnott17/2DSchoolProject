using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] private float _shootTimer;
    [SerializeField] private int _maxVolleys = 3;

    private float _timer = 3f;
    private int _volleysFired = 0;

    private bool _isAlarmActive = false;


    public void SoundAlarm()
    {
        if(!_isAlarmActive)
        {
            Debug.Log("Enemy Sighted");
            _isAlarmActive = true;
            _volleysFired = 0;
            _timer = _shootTimer;
        }
    }

    private void Update()
    {
        if (_isAlarmActive)
        {
            _shootTimer += Time.deltaTime;

            if (_shootTimer >= _timer)
            {
                FireAway();
                _shootTimer = 0;
                _volleysFired += 1;
                if(_volleysFired >= _maxVolleys)
                {
                    Debug.Log("Max shots reached");
                    _isAlarmActive = false;
                }
            }
        }
    }

    private void FireAway()
    {
        InvaderShoot[] allInvaders = GetComponentsInChildren<InvaderShoot>();

        foreach(InvaderShoot ship in allInvaders)
        {
            //Giving a random delay to the enemy ships firing time
            float ranadomDelay = Random.Range(0f, 1.5f);

            ship.FireWithDelay(ranadomDelay);
        }
    }
}
