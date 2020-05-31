using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 0.5f;

    //visualize the radius where the player can interact with the item
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
