using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform target; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ///Checking if the collision object has a rigidbody
        if(other.GetComponent<Rigidbody2D>() == true)
        {
            Debug.Log("Entered the door");
            other.transform.position = target.position + new Vector3(1.5f, 0, 0);
            other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        }
    }

    
}
