using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float liftingForce = 5f;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_rigidbody.isKinematic)
            {
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }

            Debug.Log("Jumping");
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            isDead = true;
            Debug.Log("Game over!");
        }
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector2.up * liftingForce, ForceMode2D.Impulse);
    }
}