using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum invaderMoveStates
{
    moveLeft,
    moveRight,
}
public class InvadersMovement : MonoBehaviour
{
    private  invaderMoveStates _state;

    [SerializeField] private int _speed = 3;

    private float _rightBoundary = 9f;
    private float _leftBoundary = -9f;

    private Vector2 _direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _state = invaderMoveStates.moveRight;
    }

    // Update is called once per frame
    void Update()
    {
        switch( _state)
        {
            case invaderMoveStates.moveRight:
                StartCoroutine(MoveRight());
                break;

            case invaderMoveStates.moveLeft:
                StartCoroutine(MoveLeft());
                break;
        }
    }

    private IEnumerator MoveRight()
    {
        //Setting the movement direction to the right
        _direction = new Vector2(1, 0);

        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);

        if (transform.position.x > _rightBoundary)
        {
            _direction = new Vector2(0, -0.5f);

            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(0.5f);

            _state = invaderMoveStates.moveLeft;
        }
    }

    private IEnumerator MoveLeft()
    {
        //Setting the movement direction to the left
        Vector2 direction = new Vector2(-1, 0);

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);

        if (transform.position.x < _leftBoundary)
        {
            _direction = new Vector2(0, -0.5f);

            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);

            yield return new WaitForSeconds(0.5f);

            _state = invaderMoveStates.moveRight;
        }
    }
}
