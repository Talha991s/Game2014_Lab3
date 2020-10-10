using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float VerticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBound();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, VerticalSpeed, 0.0f);
    }

    private void _CheckBound()
    {
        // if background is lower than buttom of the screen
        if(transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }

    }
}
