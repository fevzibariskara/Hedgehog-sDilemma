using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speed, maxSpeed, minSpeed, minAngle, maxAngle, maxForceDuration;
    Rigidbody2D rb;
    float forceDuration = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AddForceAtAngle();
    }

    public void AddForceAtAngle()
    {
        var angle = Random.Range(minAngle, maxAngle);

        float xComponent = Mathf.Cos(angle * Mathf.PI / 180) * minSpeed;
        float yComponent = Mathf.Sin(angle * Mathf.PI / 180) * minSpeed;

        rb.AddForce(new Vector2(xComponent, yComponent), ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (forceDuration < maxForceDuration)
        {
            rb.AddForce(rb.velocity.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
            forceDuration += Time.deltaTime;
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arena"))
        {
            rb.AddForce(rb.velocity.normalized * 0.02f, ForceMode2D.Impulse);
        }
    }
}



//public class BallMovement : MonoBehaviour
//{
//    [SerializeField] float maxSpeed = 1.5f;
//    [SerializeField] float minSpeed = 1f;
//    [SerializeField] float minAngle = 0f;
//    [SerializeField] float maxAngle = 360f;
//    [SerializeField] float maxForceTime = 1f;
//    [SerializeField] float forceMultiplier = 1f;
//    [SerializeField] float forceTimeMultiplier = 1f;
//    [SerializeField] float collisionForce = 0.02f;

//    Rigidbody2D rb;
//    float currentForceTime = 0f;
//    bool addForce = true;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        Invoke("AddForceAtAngle", 1f);
//    }

//    public void AddForceAtAngle()
//    {
//        var angle = Random.Range(minAngle, maxAngle);

//        float xComponent = Mathf.Cos(angle * Mathf.Deg2Rad) * minSpeed;
//        float yComponent = Mathf.Sin(angle * Mathf.Deg2Rad) * minSpeed;

//        rb.AddForce(new Vector2(yComponent, xComponent), ForceMode2D.Impulse);
//    }

//    private void FixedUpdate()
//    {
//        if (addForce && currentForceTime < maxForceTime)
//        {
//            float forceTime = Mathf.Min(maxForceTime - currentForceTime, Time.fixedDeltaTime);
//            float force = forceMultiplier * forceTimeMultiplier * forceTime;
//            rb.AddForce(rb.velocity.normalized * force, ForceMode2D.Force);
//            currentForceTime += forceTime;
//        }
//        else
//        {
//            addForce = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D other)
//    {
//        if (other.gameObject.CompareTag("Arena"))
//        {
//            rb.AddForce(rb.velocity.normalized * collisionForce, ForceMode2D.Impulse);
//        }
//    }

//    private void Update()
//    {
//        if (rb.velocity.magnitude > maxSpeed)
//        {
//            rb.velocity = rb.velocity.normalized * maxSpeed;
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallMovement : MonoBehaviour
//{
//    [SerializeField] float speed, maxSpeed, minSpeed, 
//        minAngle, maxAngle;
//    Rigidbody2D rb;

//    void Start()
//    {
//        AddForceAtAngle();


//        //var direction = Random.Range(minDirection, maxDirection);
//        //rb = GetComponent<Rigidbody2D>();
//        //rb.AddForce(new Vector2(direction * Time.deltaTime * speed, direction * Time.deltaTime * speed));
//    }

//    public void AddForceAtAngle()
//    {
//        var angle = Random.Range(minAngle, maxAngle);
//        rb = GetComponent<Rigidbody2D>();

//        float xComponent = Mathf.Cos(angle * Mathf.PI / 180) * minSpeed;
//        float yComponent = Mathf.Sin(angle * Mathf.PI / 180) * minSpeed;

//        rb.AddForce(new Vector2(yComponent, xComponent));
//    }

//    private void Update()
//    {
//        if (rb.velocity.magnitude > maxSpeed)
//        {
//            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
//        }
//    }
//}
