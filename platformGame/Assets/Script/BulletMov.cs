using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    private Rigidbody2D bullRb2d;
    private Transform playTrans;
    private GameObject player;
    public float bullSpeed;
    public float bullLife;

    void Awake()
    {
        bullRb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playTrans = player.transform;
    }

    void Start ()
    {
        if (playTrans.localScale.x > 0)
        {
            bullRb2d.velocity = new Vector2(bullSpeed, bullRb2d.velocity.y);
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            bullRb2d.velocity = new Vector2(-bullSpeed, bullRb2d.velocity.y);
            transform.localScale = new Vector3(-1,1,1);
        }
	}
	
	void Update ()
    {
        

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
           // Debug.Log("problema");
        }
        else
        {
            Destroy(gameObject, bullLife);
        }
        
    }
}
