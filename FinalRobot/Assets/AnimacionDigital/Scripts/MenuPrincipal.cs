using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update


    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
        Debug.Log("Salgo");
        Application.Quit();
    }
}
