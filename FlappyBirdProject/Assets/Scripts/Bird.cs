using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//TODO : Require component
//TODO : Init component
public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public CircleCollider2D circleCollider;

    public float jumpForce = 5f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    public void Flap() 
    { 
        rigidBody.velocity = Vector2.up * jumpForce;
    }
}
