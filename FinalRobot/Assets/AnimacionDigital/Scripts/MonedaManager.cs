using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MonedaManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MonedaManager instancia;
    public TextMeshProUGUI texto;
    public static int nMonedas=0;
    void Start()
    {
        if (instancia == null)
            instancia = this;
    }

    // Update is called once per frame
    void Update()
    {
        Scene escena = SceneManager.GetActiveScene();
        
        if (escena.name.Equals("EscenaMenu"))
        {
            nMonedas = 0;
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
    public void CuentoMonedas(int numero)
    {
        nMonedas += numero;
        texto.text = "Coins: " + nMonedas.ToString();


    }
}
