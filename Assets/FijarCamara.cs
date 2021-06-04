using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijarCamara : MonoBehaviour
{
    [SerializeField] GameObject scriptCubo;
    GameObject cuboObjetivo;
    

    private void Update()
    {
        cuboObjetivo = scriptCubo.GetComponent<GenerateBlock>().lastBlock;
        var tposY = gameObject.transform.position;
        tposY.y = cuboObjetivo.transform.position.y;
        gameObject.transform.position = tposY;
    }
}
