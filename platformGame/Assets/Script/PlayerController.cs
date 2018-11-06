using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumPower = 6.5f;
    public Transform blasterSpawner;
    public GameObject blasPrefab;
    public Transform surfSpaw;
    public GameObject surfPrefab;
    public static bool attack;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sr;
    private bool jump;
    private bool dolbleJump;
    private bool movement = true;



    Vector2 mov;

    CircleCollider2D ca2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ca2d = transform.GetChild(0).GetComponent<CircleCollider2D>();
	}
	
	void Update ()
    {
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        if (grounded)
        {
            dolbleJump = true;
        }
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        attack = stateInfo.IsName("Player_Attack");
        if (Input.GetKeyDown (KeyCode.Mouse1) && attack == false) 
        {
            anim.SetTrigger("Attacking");
            attack = true;
            StartCoroutine(Att());
        }
        if(mov != Vector2.zero) ca2d.offset = new Vector2(mov.x / 2,0);
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                jump = true;
                dolbleJump = true;
            }
            else if (dolbleJump)
            {
                jump = true;
                dolbleJump = false;

            }
        }
        Fire();
        SurfObjec();
	}

    void FixedUpdate()
    {
        Vector3 fixVel = rb2d.velocity;
        fixVel.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixVel;
        }

        mov.x = Input.GetAxis("Horizontal");
        if (!movement) mov.x = 0;
        rb2d.AddForce(Vector2.right * speed * mov);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        if (mov.x > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        if (mov.x < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector2(12.754f, 2.0613f);  
    }

    public void EnemyJump()
    {
        jump = true;
    }
    public void Retroceso (float enemyPos)
    {
        jump = true;
        float side = Mathf.Sign(enemyPos - transform.position.x);
        float up = Mathf.Sign(enemyPos + transform.position.y);
        rb2d.AddForce(Vector2.left * side * jumPower, ForceMode2D.Impulse);
        movement = false;
        Invoke("EnableMovement", 0.7f);
        sr.color = Rainbow(6);
    }

    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(blasPrefab, blasterSpawner.position, blasterSpawner.rotation);
            anim.SetBool("isFire", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("isFire", false);
        }

    }
    public void SurfObjec()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(surfPrefab, surfSpaw.position, surfSpaw.rotation);
        }
    }

    void EnableMovement()
    {
        movement = true;
        sr.color = Color.white;
    }

    private Color Rainbow(float t)
    {
        float h, s, v, a;
        Color baseColor = Color.white;
        Color.RGBToHSV(baseColor, out h, out s, out v);
        h = Mathf.PingPong(Time.time * t , 1);
        s = 1;
        v = 1;
        a = 1;
        Color rainbow = Color.HSVToRGB(h, s, v);
        rainbow.a = a;
        return rainbow;
    }

    IEnumerator Att ()
    {
        yield return new WaitForSeconds(0.36f);
        attack = false;
    }
}
