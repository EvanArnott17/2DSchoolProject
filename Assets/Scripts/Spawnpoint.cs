using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private float size = 0.5f;

    [SerializeField] private Color gizmoColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, size);
    }


}
