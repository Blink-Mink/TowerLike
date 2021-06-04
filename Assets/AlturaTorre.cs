using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlturaTorre : MonoBehaviour
{

    private int altura;
    public Text txtobj;
    public List<GameObject> constructedBlocks;
    // Start is called before the first frame update
    void Start()
    {
        altura = 0;
        constructedBlocks = new List<GameObject>();
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
    public void NuevoPiso(GameObject objB)
    {
        altura++;
        constructedBlocks.Add(objB);
    }

    public void RemoverPiso(GameObject objB)
    {
        altura--;
        constructedBlocks.Remove(objB);
        GetComponent<ControlCamara>().PisoRemovido(objB);
    }
}
