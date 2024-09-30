using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidBody = null;
    private CircleCollider2D circleCollider = null;

    public UnityEvent onScore;

    public IEnumerator deathCoroutine;

    public float pipeSpeed = 1f;
    public float jumpForce = 5f;

    public bool IsAlive = true;
    public bool HasStart = false;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();

        IsAlive = true;
        HasStart = false;

        Pipe.globalSpeed = 0;
        rigidBody.isKinematic = true;
    }

    private void OnValidate()
    {
        Pipe.globalSpeed = pipeSpeed;
    }

    private void Update()
    {
        if(IsAlive == false)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(HasStart == false)
            {
                HasStart = true;
                rigidBody.isKinematic = false;
                Pipe.globalSpeed = pipeSpeed;
            }

            Flap();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsAlive == false)
        {
            return;
        }

        deathCoroutine = PlayerDeath();
        StartCoroutine(deathCoroutine);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsAlive == false)
        {
            return;
        }

        onScore.Invoke();
    }

    public IEnumerator PlayerDeath()
    {
        IsAlive = false;
        Pipe.globalSpeed = 0;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Flap() 
    { 
        rigidBody.velocity = Vector2.up * jumpForce;
    }
}
