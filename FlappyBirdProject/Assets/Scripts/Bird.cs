using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

//TODO : Require component
//TODO : Init component
public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public CircleCollider2D circleCollider;

    public UnityEvent onDeath;

    public float jumpForce = 5f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        onDeath.Invoke();
    }

    public void Flap() 
    { 
        rigidBody.velocity = Vector2.up * jumpForce;
    }
}
