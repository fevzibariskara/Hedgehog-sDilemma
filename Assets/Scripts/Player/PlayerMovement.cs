using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform m_transform;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    private void Start()
    {
        m_transform = this.transform;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");        
        movement.y = Input.GetAxisRaw("Vertical");
        LookAtMouse();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void LookAtMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        m_transform.rotation = rotation;
    }
}
