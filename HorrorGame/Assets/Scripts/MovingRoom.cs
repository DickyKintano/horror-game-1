using UnityEngine;

public class MovingRoom : MonoBehaviour
{

    [SerializeField] private GameObject targetLocation;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currArea;
    [SerializeField] private GameObject targetArea;


    //need to remove this script later
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currArea.SetActive(false);
        targetArea.SetActive(true);

        player.transform.position = targetLocation.transform.position;
    }

}
