using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float verticalspeed;
    public float VerticalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBound();
    }
    private void _Reset()
    {
        transform.position = new Vector3(0.0f, VerticalBoundary);
    }
    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalspeed);
    }

    private void _CheckBound()
    {
        // if background is lower than buttom of the screen
        if(transform.position.y <= -VerticalBoundary)
        {
            _Reset();
        }
    }
}
