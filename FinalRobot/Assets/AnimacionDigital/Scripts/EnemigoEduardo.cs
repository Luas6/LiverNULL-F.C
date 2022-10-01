using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEduardo : MonoBehaviour
{

    public float velocidad = 2f;
    
    public float yOff = 1.4f;
    

    //public GameObject prefabDisparoBob;
    protected Rigidbody2D rigidBody2D;
    //protected Animator animator;
    protected Collider2D collider2d;
    protected AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        rigidBody2D = GetComponent<Rigidbody2D>();
        //rigidBody2D.velocity = new Vector2(velocidad, 0);
        //animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.name.StartsWith("Platfo"))
        {
            audioSource.Play();
            
        }

    }
}
