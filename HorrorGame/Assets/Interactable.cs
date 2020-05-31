using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

