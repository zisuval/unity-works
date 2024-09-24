using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;

    [SerializeField] float gravityScale = 5f;
    [SerializeField] float fallGravityScale = 8f;

    private Rigidbody2D pRb;
    //Åö×²¼ì²â,·ÀÖ¹ÉýÌì
    public LayerMask mask;
    public float boxHeight = 0.5f;
    private Vector2 playerSize;
    private Vector2 boxSize;

    private bool jumpRequest = false;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        pRb = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(playerSize.x * 0.8f, boxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumpRequest = true;

        }
        Debug.Log(grounded);
    }
    private void FixedUpdate()
    {
        float dt = Time.deltaTime;
        if (jumpRequest)
        {
            pRb.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * pRb.gravityScale) * -2) * pRb.mass;
            pRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequest = false;
            grounded = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + (Vector2.down * playerSize.y * 0.5f);
            Debug.Log(boxCenter);
            if (Physics2D.OverlapBox(boxCenter, boxSize, 0, mask) != null)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        //
        if (pRb.velocity.y > 0)
        {
            pRb.gravityScale = gravityScale;
        }
        if (pRb.velocity.y < 0)
        {
            pRb.gravityScale = fallGravityScale;
        }
        //
    }
}
