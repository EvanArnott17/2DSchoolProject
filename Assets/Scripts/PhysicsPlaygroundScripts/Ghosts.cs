
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    void Start()
    {
        // LINE 4
        Debug.Log("Hello I am ghost " + gameObject.name + ", over");

        // LINE 7
        GetComponent<SpriteRenderer>().color = Color.azure;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // LINE 10
    void Update()
    {
        // LINE 12
        transform.Rotate(0, 0, 1);
    }
}
