using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;
    public List<GameObject> fxObjects; //Añadimos los prefabs que sean sistemas de partículas
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void InstantitateFX(int i,Transform transform) //Llamar a este método cuando queramos instanciar un FX en un lugar.
    {
        Instantiate(fxObjects[i], transform.position, Quaternion.identity);
    }
}
