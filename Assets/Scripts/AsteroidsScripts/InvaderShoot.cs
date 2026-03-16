using UnityEngine;

public class InvaderShoot : MonoBehaviour
{
    [SerializeField] private GameObject _laser;

    [SerializeField] private Transform _firePoint;

    public void FireLaser()
    {
        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position;
        Instantiate(_laser, spawnPos, transform.rotation);
    }
}
