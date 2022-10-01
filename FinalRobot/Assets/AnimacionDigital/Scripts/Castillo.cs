using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castillo : MonoBehaviour
{
    public int EscenaAIr = 2;
    protected AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.StartsWith("Jugad"))
        {
            audioSource.Play();
            SceneManager.LoadScene(EscenaAIr);
        }
    }
}
