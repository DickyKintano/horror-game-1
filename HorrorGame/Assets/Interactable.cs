using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("Range where player can interact with the object")]
    public float radius = 0.5f;
    public Transform player;
    public Transform interactionTransform;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius && Input.GetButtonDown("Interact"))
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

