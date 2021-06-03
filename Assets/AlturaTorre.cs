using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlturaTorre : MonoBehaviour
{

    private int altura;
    public Text txtobj;
    // Start is called before the first frame update
    void Start()
    {
        altura = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtobj.text = altura.ToString();
    }

    public int RetAltura()
    {
        return altura;
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
