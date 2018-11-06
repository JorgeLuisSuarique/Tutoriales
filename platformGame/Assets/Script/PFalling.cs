using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFalling : MonoBehaviour
{
    public float delay = 1f;
    public float resDelay = 5f;

    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    private Vector3 savePlat;
    
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        savePlat = transform.position;
	}
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col2D)
    {
        if (col2D.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", delay);
            Invoke("Respawn", delay + resDelay);
        }
        
    }
    void Fall()
    {
        rb2d.isKinematic = false;
        pc2d.isTrigger = true;
    }
    void Respawn()
    {
        transform.position = savePlat;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        pc2d.isTrigger = false;
    }
}
