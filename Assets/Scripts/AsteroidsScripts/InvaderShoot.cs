using System.Collections;
using UnityEngine;

public class InvaderShoot : MonoBehaviour
{
    [SerializeField] private GameObject _laser;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private InvaderStats _stats;

    public void FireLaser()
    {
        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position;
        Instantiate(_laser, spawnPos, transform.rotation);
    }

    public void FireWithDelay(float delayTime)
    {
        StartCoroutine(FireRoutine(delayTime));
    } 

    private IEnumerator FireRoutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Vector3 spawnPos = _firePoint != null ? _firePoint.position : transform.position;

        Instantiate(_laser, spawnPos, transform.rotation);
    }
}
