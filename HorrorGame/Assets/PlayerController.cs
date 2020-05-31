using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float rayRange = 5f;
    [SerializeField] private GameObject originPoint;

    private Rigidbody2D playerRB;
    private string dir = "right";
    private float movementSmoothing = 0.05f;
    private float xMove;
    private float yMove;
    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // get player's rigid body
        if (playerRB == null)
        {
            playerRB = player.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        print("xMove: " + xMove);
        Vector2 playerPos = player.transform.position;
        
        //move the origin point to the direction the player is facing
        if (xMove == 1 && dir != "right")
        {
            originPoint.transform.position = new Vector2(playerPos.x + 0.5f, playerPos.y);
            dir = "right";
        }

        if (xMove == -1 && dir != "left")
        {
            originPoint.transform.position = new Vector2(playerPos.x - 0.5f, playerPos.y);
            dir = "left";
        }

        if (yMove == 1 && dir != "up")
        {
            originPoint.transform.position = new Vector2(playerPos.x, playerPos.y + 0.5f);
            dir = "up";
        }

        if(yMove == -1 && dir != "down")
        {
            originPoint.transform.position = new Vector2(playerPos.x, playerPos.y - 0.5f);
            dir = "down";
        }



        if (Input.GetButtonDown("Interact"))
        {
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

        Debug.Log("dir: " + dir);

        if (dir == "right")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, originPoint.transform.right, rayRange);
        } else if (dir == "left")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(-1, 0), rayRange);
        } else if (dir == "up")
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(0, 1), rayRange);
        } else
        {
            hit = Physics2D.Raycast(originPoint.transform.position, new Vector2(0, -1), rayRange);
        }

        if (hit)
        {
            Debug.Log(hit.transform.name + " at positiion " + hit.transform.position);
        }
       
    }


}
