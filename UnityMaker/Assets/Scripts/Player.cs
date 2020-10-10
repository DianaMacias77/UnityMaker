using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Control")]
    public float speed = 10;
    public float jumpSpeed = 5;

    [Header("GroundCheck")]
    public Transform groundCheckPosition;
    public Vector2 groundCheckSize;

    SpriteRenderer sr;
    Rigidbody2D rb;
    BetterJump bt;
    float horizontalAxis;
    bool ground;
    bool jumpRequest = false;
   
   

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bt = GetComponent<BetterJump>();

        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        ground = isGround;

        ManageFlip();
        ManageJump();
        
        //gameObject.transform.Translate(new Vector2(horizontal,0));
    }
    public bool isGround
    {
        get
        {
            var cc = Physics2D.BoxCast(groundCheckPosition.position, groundCheckSize, 0, Vector2.zero);
            if (cc.collider == null)
                return false;
            if (cc.collider.gameObject == gameObject)
                return false;
            return true;
        }
    }
    void onDrawGizmosSelected()
    {
        if (!groundCheckPosition)
            return;
        Gizmos.DrawWireCube ((Vector3) groundCheckPosition.position, (Vector3)groundCheckSize);
    }
    void FixedUpdate()
    {
        if (jumpRequest)
        {
            jumpRequest = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector3(InputManager.HorizontalAxis * speed, rb.velocity.y);
        bt.ApplyBetterJump();
    }
    void ManageFlip()
    {
        if (horizontalAxis != 0)
            sr.flipX = horizontalAxis < 0;
    }
    void ManageJump()
    {
        if (InputManager.JumpButtonPressed)
        {
            if (ground)
            {
                jumpRequest = true;
            }
        }

    }
   /* IEnumerator DelayedEvents(System.Action ev, float time)
    {
        yield return new WaitForSeconds(time);
        ev();
    }
   */

 
}
