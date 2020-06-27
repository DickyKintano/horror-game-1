using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("Range where player can interact with the object")]
    public float radius = 0.5f;
    public Transform interactingObject;
    public Transform interactionTransform;
    public bool hasInteracted = false;

    private void Update()
    {
        float distance = Vector3.Distance(interactingObject.position, interactionTransform.position);
        if (distance <= radius && hasInteracted)
        {
            Debug.Log("Interact");
            Interact();
        }
    }

    public void SetInteractingParam(Transform tranform, bool hasInteract)
    {
        interactingObject = transform;
        hasInteracted = hasInteract;
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

