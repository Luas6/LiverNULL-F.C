using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBob : MonoBehaviour
{
    public float velocidad = -3.0f;
    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, velocidad);

        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        
        

        
        Destroy(gameObject);

        
    }

}
