using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuerda : MonoBehaviour
{
    [Header("Velocidades Cuerda")]
    [SerializeField] private float outSpeed = 1f;
    [SerializeField] private float inSpeed = 2f;   


    [Header("Variables Públicas No Editables")]
    public bool DoCraneOut;

    //Variables No Mostradas en el Editor
    private bool DoCraneIn;   


    void Start()
    {       
        DoCraneIn = false;
        DoCraneOut = false;
    }

    private void Update()
    {
        if (transform.position.y <= 8.22f)
        {           
            DoCraneIn = false;
            GetComponent<GenerateBlock>().EnableBlockInput();
        }

        if (DoCraneOut)
        {
            CraneOut();
        }

        if (DoCraneIn)
        {
            CraneIn();
        }
    }

    public void CraneOut()
    {
        var pendPos = transform.position;
        pendPos.y += outSpeed * Time.deltaTime;
        transform.position = pendPos;
        if (transform.position.y > 13)
        {
            GetComponent<GenerateBlock>().DisableBlockInput();
            DoCraneOut = false;
            GetComponent<GenerateBlock>().GenerateNewBlock();
            DoCraneIn = true;
        }
    }

    public void CraneIn()
    {
        var pendPos = transform.position;
        pendPos.y -= inSpeed * Time.deltaTime;
        transform.position = pendPos;
    }
    
}
