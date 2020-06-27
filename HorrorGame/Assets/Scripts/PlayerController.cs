using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private GameObject originPoint;
    [SerializeField] private float dist = 0.5f;

    private string dir;
    private Rigidbody2D playerRB;
    private Vector2 velocity = Vector2.zero;
    private float movementSmoothing = 0.05f;
    private float xMove;
    private float yMove;

    // Start is called before the first frame update
    void Start()
    {
        // get player's rigid body
        if (playerRB == null)
        {
            playerRB = GetComponent<Rigidbody2D>();
        }

        dir = "";
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        //change the position of "originPoint" based on the player input
        if (xMove == 1 && dir != "right")
        {
            originPoint.transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y);
        }

        if (xMove == -1 && dir != "left")
        {

            originPoint.transform.position = new Vector2(player.transform.position.x - 0.5f, player.transform.position.y);
        }

        if (yMove == 1 && dir != "up")
        {
            originPoint.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
        }

        if (yMove == -1 && dir != "down")
        {
            originPoint.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.5f);
        }

        if (Input.GetButtonDown("Interact")) {
            Interact();
        }

    }

    private void FixedUpdate()
    {
        Move(xMove * moveSpeed * Time.deltaTime, yMove * moveSpeed * Time.deltaTime);
    }

    private void Move(float x, float y)
    {
        Vector2 movement = new Vector2(x * 10f, y * 10f);

        playerRB.velocity = Vector2.SmoothDamp(playerRB.velocity, movement, ref velocity, movementSmoothing);

        //animation down here
    }

    private void Interact()
    {
        RaycastHit2D hit;

        if (dir == "right")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, originPoint.transform.right, dist);
        }
        else if (dir == "left")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(-1, 0), dist);
        }
        else if (dir == "up")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(0, 1), dist);
        }
        else
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(0, -1), dist);
        }

        if (hit)
        {
            Debug.Log(hit.transform.name);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            Debug.Log("interactable: " + interactable);
            if (interactable != null)
            {
                SetInteractingParam(interactable);
            }
        }
    }

    //
    private void SetInteractingParam(Interactable interactingObject)
    {
        interactingObject.SetInteractingParam(transform, true);
    }
}
