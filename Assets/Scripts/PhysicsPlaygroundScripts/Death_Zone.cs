using UnityEngine;

public class Death_Zone : MonoBehaviour
{

    [SerializeField] private GameObject pinball;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() == true)
        {
            Debug.Log("Player Dead");
            GameManager.instance.OnPlayerDied();
        }
    }

    
}
