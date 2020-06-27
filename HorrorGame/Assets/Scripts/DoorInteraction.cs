using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : Interactable
{
    [Tooltip("New Area where player is moving to")]
    [SerializeField] private GameObject targetArea;

    [Tooltip("Area where player are currently located")]
    [SerializeField] private GameObject currArea;

    [Tooltip("Target point where player is moving to")]
    [SerializeField] private Transform targetPoint;

    [Tooltip("Determine if the door is locked or not")]
    [SerializeField] private bool isLocked = false;

    [SerializeField] private Animator transition;

    [SerializeField] private GameObject transitionCanvas;

    public override void Interact()
    {
        base.Interact();

        if (!isLocked)
        {
            /*
            player.position = targetPoint.position;
            targetArea.SetActive(true);
            currArea.SetActive(false);
            */
            StartCoroutine(OpenDoor());
        } else
        {
            //put out a dialog "door is locked"
        }
    }

    IEnumerator OpenDoor()
    {
        //need to disable player movement
        transition.SetTrigger("travelling");
        targetArea.SetActive(true);
        yield return new WaitForSeconds(1f);
        interactingObject.position = targetPoint.position;
        currArea.SetActive(false);
    }
}
