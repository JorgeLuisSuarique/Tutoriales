using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController play;
    private Rigidbody2D rb2d;

	void Start ()
    {
        play = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if (col2d.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f,0f,0f);
            play.transform.parent = col2d.transform;
            play.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            play.transform.parent = collision.transform;
            play.grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            play.transform.parent = null;
            play.grounded = false;
        }
    }
}
