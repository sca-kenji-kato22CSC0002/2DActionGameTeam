using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float moveSpeed = 5;
    [SerializeField]private float jumpPower = 5;

    //アニメーション
    private Animator anim;
    string trigger_Jump = "Jump";
    string trigger_Attack = "Attack";
    string bool_Run = "Run";
    string bool_onGround = "onGround";
    string bool_JumpUp = "Jump_Up";
    string bool_isJump = "isJump";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Attack();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
            anim.SetBool(bool_Run, true);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
            anim.SetBool(bool_Run, true);
        }
        else
        {
            anim.SetBool(bool_Run, false);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger(trigger_Attack);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            anim.SetTrigger(trigger_Jump);
        }

        anim.SetBool(bool_JumpUp, rb.linearVelocityY > 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            anim.SetBool(bool_onGround,true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool(bool_onGround, false);
        }
    }
}
