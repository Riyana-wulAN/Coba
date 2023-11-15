using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float turnAround = -5f;



    // Update is called once per frame
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpDirection = new Vector2(0, 1);
            rb.velocity = jumpDirection * jumpSpeed;
        }

    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontal, 0); //Kanan
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}