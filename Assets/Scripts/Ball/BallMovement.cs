using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speed, maxSpeed, minSpeed, 
        minAngle, maxAngle;
    Rigidbody2D rb;

    void Start()
    {
        AddForceAtAngle();


        //var direction = Random.Range(minDirection, maxDirection);
        //rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(direction * Time.deltaTime * speed, direction * Time.deltaTime * speed));
    }

    public void AddForceAtAngle()
    {
        var angle = Random.Range(minAngle, maxAngle);
        rb = GetComponent<Rigidbody2D>();

        float xComponent = Mathf.Cos(angle * Mathf.PI / 180) * minSpeed;
        float yComponent = Mathf.Sin(angle * Mathf.PI / 180) * minSpeed;

        rb.AddForce(new Vector2(yComponent, xComponent));
    }

    private void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
