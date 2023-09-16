using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    float horizontal;
    float vertical;
    public Animator thisAnim;
    public SpriteRenderer sr;
    public bool isJumping = false;
    public LayerMask jumpableGround;
    
    public float jumpForce;
    public float moveSpeed;
    public float waitTime;
    float timePassed = 0.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal > 0.1f || horizontal < -0.1f) {
            thisAnim.SetBool("isWalking", true);
            if (horizontal < 0) {
                sr.flipX = true;
            } else {
                sr.flipX = false;
            }
        } else {
            thisAnim.SetBool("isWalking", false);
        }

        timePassed += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        transform.position = position;
        if (IsGrounded() && vertical > 0.1f && timePassed > waitTime) {
            // position.y = position.y + jumpForce * vertical;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            timePassed = 0f;
        }
    }

    // void OnCollisionEnter2D(Collision2D collider) {
    //     Debug.Log(collider.gameObject.name);
    //     if (collider.gameObject.tag == "Ground") {
    //         isJumping = false;
    //     }
    // }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
