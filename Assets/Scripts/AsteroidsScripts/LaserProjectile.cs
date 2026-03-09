using UnityEngine;
using System.Collections;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _killTime = 3f;

    private void Start()
    {
        StartCoroutine(CleanupRoutine());
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator CleanupRoutine()
    {
        yield return new WaitForSeconds(_killTime);

        Debug.Log("Kill Timer test");

        //Destroying the gameObject when the timer has finished
        Destroy(gameObject);
    }
}
