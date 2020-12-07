using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    private float moveInput;
    [SerializeField]
    private float speed = 10f;

    private bool facingLeft = false;

    private SpriteRenderer spriteRenderer;

    public float gravityScaleStore;

    public AudioSource jumpSound;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gravityScaleStore = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveInput * speed, rigidbody2D.velocity.y);
        FlipPlayerModel(moveInput);
    }

    private void FlipPlayerModel(float horizontal)
    {
        if ((horizontal > 0 && facingLeft) || (horizontal < 0 && !facingLeft))
        {
            facingLeft = !facingLeft;
            spriteRenderer.flipX = facingLeft;
        }
    }
}
