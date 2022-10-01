using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    protected MeshRenderer meshRenderer;
    public float velocidad = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0, Time.time * velocidad));
    }
}
