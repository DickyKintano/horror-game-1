using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float moveSpeed = 40f;

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
            playerRB = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
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


}
