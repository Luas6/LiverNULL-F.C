using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    protected MeshRenderer meshRenderer;
    public float velocidadFondo = -0.01f;
    public float velocidadMedio = 0.04f;
    public float velocidadFrente = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0, Time.time * velocidadFondo));
        meshRenderer.materials[1].SetTextureOffset("_MainTex", new Vector2(Time.time * velocidadMedio, 0));
        meshRenderer.materials[2].SetTextureOffset("_MainTex", new Vector2(0, Time.time * velocidadFrente));
    }
}
