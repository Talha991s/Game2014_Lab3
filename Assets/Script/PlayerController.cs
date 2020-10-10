using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;


    private Rigidbody2D m_rigidBody;
    public float horizontalspeed;
    public float horizontalboundary;
    public float maxSpeed;
    private Vector3 touchesEnd;
    // Start is called before the first frame update
    void Start()
    {
        touchesEnd = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBound();
        _FireBullet();
    }
    private void _FireBullet()
    {
        //delay bullet firing every 40 frames
        if (Time.frameCount % 40 == 0)
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    private void _Move()
    {
        float direction = 0.0f;
        //simple touche imput


        //touch support
        foreach (var touch in Input.touches)
        {
            var worldtouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldtouch.x > transform.position.x)
            {
                direction = 1.0f;
            }

            if (worldtouch.x < transform.position.x)
            {
                direction = -1.0f;
            }
            touchesEnd = worldtouch;
        }


        // var touch = Input.touches[];
       // var worldtouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
        //keyboard 
        if(Input.GetAxis("Horizontal") >= 0.1f)
        {
            //direction is positive
            direction = 1.0f;
        }

        if(Input.GetAxis("Horizontal") <= -0.1f)
        {
            //direction is neative
            direction = -1.0f;
        }



        if(touchesEnd.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchesEnd.x, 0.02f), transform.position.y);   // Vector2.Lerp(transform.position, touchesEnd, 0.0f);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalspeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed); // clamp it to whatever the rigid bodu speed will be till the max speed and not more
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBound()
    {
        if(transform.position.x >= horizontalboundary)
        {
            transform.position = new Vector3(horizontalboundary, transform.position.y, 0.0f);
        }

        if (transform.position.x <= -horizontalboundary)
        {
            transform.position = new Vector3(-horizontalboundary, transform.position.y, 0.0f);
        }
        // check left and right bound

    }
}
