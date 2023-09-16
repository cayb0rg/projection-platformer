using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public Animator thisAnim;
    public SpriteRenderer sr;
    public bool isJumping = false;
    
    public float jumpForce = 0.1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        if (!isJumping && vertical > 0) {
            // position.y = position.y + jumpForce * vertical;
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (horizontal > 0 || horizontal < 0) {
            thisAnim.SetBool("isWalking", true);
            if (horizontal < 0) {
                sr.flipX = true;
            } else {
                sr.flipX = false;
            }
        } else {
            thisAnim.SetBool("isWalking", false);
        }
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collider) {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }
}
