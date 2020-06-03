using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform interactionTransform;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius)
        {
            Interact();
            Debug.Log("Interact");
        }
    }

    public void SetInteractingPlayer(Transform tranform)
    {
        player = transform;
    }

    public virtual void Interact()
    {
        //this method meant to be overwritten
        Debug.Log("interacting with " + interactionTransform.name);
    }

    private void OnDrawGizmos()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

