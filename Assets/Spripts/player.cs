using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    //ÒÆ¶¯
    private float moveSpeed = 6.0f;
    private Vector3 pScale = Vector3.one;
    //
    private Rigidbody2D pRb;
    //
    //private float x;
    //private float y;

    // Start is called before the first frame update
    void Start()
    {
        pRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Camera.main.GetComponent<CameraFollow>().pTraget = transform;
        //x = Input.GetAxis("Horizontal");
        //y = Input.GetAxis("Vertical");
        Move(dt);
    }
    void Turn()
    {
        pScale.x *= -1f;
        transform.localScale = pScale;
    }
    void Move(float dt)
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(moveSpeed * dt, 0, 0);
            if (pScale.x > 0)
            {
                Turn();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * dt, 0, 0);
            if (pScale.x < 0)
            {
                Turn();
            }
        }
        //Vector3 movement = new Vector3(x, y, 0);
        //pRb.transform.position += movement * moveSpeed * dt;
        //if (x < 0 && pScale.x > 0)
        //{
        //    Turn();
        //}
        //if (x > 0 && pScale.x < 0)
        //{
        //    Turn();
        //}
    }
}
