using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 600f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // if character was moving down
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                // push him up, play jump sound and animation 
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * bounceForce);
                collision.gameObject.GetComponent<Animator>().Play("Jump");
                collision.gameObject.GetComponent<PlayerController>().jumpSound.Play();
            }
        }
    }
}
