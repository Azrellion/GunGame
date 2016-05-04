using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 7.0f;
    public float jumpForce = 200f;
    float move;
   public  bool facingRight = true;
    Animator Anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

	 //Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}

     void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        Anim.SetBool("Ground", grounded);
        Anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        
        
        
        move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        Anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }

        /*if(transform.position.x <= -6.5f)
        {
            transform.position = new Vector2(-6.5f, transform.position.y);
        }
        if (transform.position.x >= 6.5f)
        {
            transform.position = new Vector2(6.5f, transform.position.y);
        }*/
    }
	// Update is called once per frame
	void Update () {

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }

	}

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
