using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMover : MonoBehaviour
{

    public float velocidad = 2f;
    protected Rigidbody2D rigidBody2D;
    protected Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(velocidad, 0);
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.StartsWith("Platform"))
        {

            velocidad = -velocidad;
            rigidBody2D.velocity = new Vector2(velocidad, 0);

        }
    }
}
