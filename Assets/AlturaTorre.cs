using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlturaTorre : MonoBehaviour
{

    public int altura;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        print("altura: "+ altura);
    }

    public void NuevoPiso()
    {
        altura++;
    }

    public void RemoverPiso()
    {
        altura--;
    }
}
