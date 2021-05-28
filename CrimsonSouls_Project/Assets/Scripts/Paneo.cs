using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paneo : MonoBehaviour
{
    public float velocidad;
    public Renderer textura;

    void Update()
    {
        textura.material.mainTextureOffset = new Vector2( velocidad * Time.time , 0);
    }
}
