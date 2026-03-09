using UnityEngine;

public class StaticObjectDrift : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _spin = 13f;
    [SerializeField] private float _leftBoundary = -10;
    [SerializeField] private float _rightBoundary = 10;

    private Vector2 direction = new Vector2(1,0);

    private void Update()
    {
        //Move Asteroid
        MoveAsteroid();


        //Spin Asteroid
        SpinAsteroid();

        //Respawing the asteroid when it moves off screen
        CheckBoundaries();
    }

    private void MoveAsteroid()
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void SpinAsteroid()
    {
        transform.Rotate(0, 0, _spin * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        if(transform.position.x > _rightBoundary)
        {
            transform.position = new Vector3(_leftBoundary, transform.position.y, transform.position.z);
        }
    }
}
