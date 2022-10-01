using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 4f;
    public float salto = 8f;
    public float velagachado = 1f;
    public float yOff = 1.4f;

    public bool agachado = false;
    
   // int AgacharId ;

    protected Rigidbody2D rigidBody2D;
    protected Animator animator;
    protected Collider2D collider2d;
    protected AudioSource audioSource;


    // Use this for initialization
    void Start()
    {

        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();



        //   AgacharId = Animator.StringToHash("Crouch");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        

        rigidBody2D.velocity = new Vector2(velocidad * Input.GetAxis ("Horizontal"), rigidBody2D.velocity.y);
        animator.SetFloat("vSpeed", rigidBody2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rigidBody2D.velocity.x));
        //roto al personaje para es lo escalo a -1 o lo giro 180 en el eje y
    if (rigidBody2D.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rigidBody2D.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        //en las rampas tendría velocidad vertical por lo que no funcionaría
        //animator.SetBool("Ground", rigidBody2D.velocity.y == 0);
        //miro a ver si hay algo en un punto que esté un poco pordebajo del personaje para así
    //saber si estoy en el suelo
    animator.SetBool("Ground", Physics2D.OverlapBox(transform.GetChild(0).position, new Vector2(collider2d.bounds.max.x-collider2d.bounds.min.x, 0), 0));

        
        /*
            animator.SetBool("Crouch", Physics2D.OverlapBox(transform.GetChild(0).position, new Vector2(collider2d.bounds.max.x - collider2d.bounds.min.x, 0), 0));
                if (animator.GetBool("Crouch"))
                    velocidad = velagachado;*/
        bool agachado = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", agachado);

        

        if (animator.GetBool("Ground") )
        {
            //boolsalto
            rigidBody2D.AddForce(new Vector2(0, Input.GetAxisRaw("Vertical") * salto), ForceMode2D.Impulse);
            
            //rigidBody2D.AddForce(new Vector2(0f, salto));
        }

    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.StartsWith("Dispa"))
        {

            animator.SetBool("Muerte", true);

            velocidad = 0f;

            //animator.SetBool("Error", true);
            Invoke("Muerte", 1);
            Invoke("Vueltamenu", 3);
            //Destroy(this.gameObject);

        }

        if (collider.gameObject.name.StartsWith("Edu"))
        {
            if (transform.position.y - yOff > collider.transform.position.y)
            {
                Destroy(collider.gameObject);
                audioSource.Play();
            }
            else
            {
                animator.SetBool("Muerte", true);

                velocidad = 0f;
                Invoke("Muerte", 1);
                Debug.Log("Funcionas");
                Invoke("Vueltamenu",3);
            }
        }
    }

 private void Muerte()
    {
        //Destroy(gameObject);
    }

    private void Vueltamenu()
    {
        Debug.Log("Quepasa");
        SceneManager.LoadScene(0);
    }

}
