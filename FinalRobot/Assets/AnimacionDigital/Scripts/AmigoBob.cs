using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmigoBob : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 2f;

    public GameObject prefabDisparoBob;
    protected Rigidbody2D rigidBody2D;
    protected Animator animator;
    protected Collider2D collider2d;

    protected AudioSource audioSource;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(velocidad, 0);
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetBool("Disparo", false);
    }

    
    public void OnCollisionEnter2D (Collision2D collider)
    {
        if (collider.gameObject.name.StartsWith("Platform") || collider.gameObject.name.StartsWith("Bob"))
        {
            
            velocidad = -velocidad;
            rigidBody2D.velocity = new Vector2(velocidad, 0);
            animator.SetBool("Disparo", true);
            disparar();
            audioSource.Play();
            //Destroy(this.gameObject);
            //Destroy(collider.gameObject);
        }
    }

    void disparar()
    {
        Instantiate(prefabDisparoBob, new Vector2(transform.GetChild(0).position.x, transform.GetChild(0).position.y), Quaternion.identity);
    }
}
