using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");   
    }

    // Update is called once per frame
    void Update()
    {
        body.position += new Vector2(1, 0) * Time.deltaTime;
    }


}
