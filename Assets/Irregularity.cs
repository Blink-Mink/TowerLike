using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Irregularity : MonoBehaviour
{
    float min = 0;
    float max = 360f;
    float t = 0;
    float timer = 0;
    [SerializeField] float duracion = 2f;
    [SerializeField] float range = 1.2f;
    float startY;

    
    private void Update()
    {
        float result = Mathf.Lerp(min, max, t);    
        if(t <= 1) { t += Time.deltaTime/duracion; }      


        timer += Time.deltaTime;
        if(timer >= duracion)
        {
            timer = 0;
            t = 0;
        }

        var posP = transform.position;
        float rad = result*Mathf.Deg2Rad;
        posP.y += (Mathf.Sin(rad)*range)*Time.deltaTime;
        transform.position = posP;

    }

    private void OnEnable()
    {
        t = 0;
        timer = 0;
    }

}
