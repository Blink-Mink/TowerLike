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
    private GameObject spawnPoint;
    private Transform pendulo;
    bool infLim;
    bool supLim;

    void Start()
    {
        DoCraneIn = false;
        DoCraneOut = false;      
        spawnPoint = GameObject.FindGameObjectWithTag("blockSpawn");
        pendulo = GameObject.FindGameObjectWithTag("pendulo").transform;
        pendulo.gameObject.GetComponent<Irregularity>().enabled = false;
    }

    private void Update()
    {
        if (infLim)
        {           
            DoCraneIn = false;
            spawnPoint.GetComponent<BlockInput>().EnableBlockInput();
        }

        if(!DoCraneIn && !DoCraneOut)
        {
            Invoke("StartIr",1f);            
        }
        else
        {
            pendulo.gameObject.GetComponent<Irregularity>().enabled = false;
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

    public void StartIr()
    {
        pendulo.gameObject.GetComponent<Irregularity>().enabled = true;
    }
    public void CraneIn()
    {
        var pendPos = pendulo.position;
        pendPos.y -= inSpeed * Time.deltaTime;
        pendulo.position = pendPos;
    } 

    public void CraneOut()
    {
        var pendPos = pendulo.position;
        pendPos.y += outSpeed * Time.deltaTime;
        pendulo.position = pendPos;
        if (supLim)
        {
            spawnPoint.GetComponent<BlockInput>().DisableBlockInput();
            DoCraneOut = false;
            spawnPoint.GetComponent<GenerateBlock>().GenerateNewBlock();
            DoCraneIn = true;
        }
    }

    public void MoveCrane(int lim)
    {
        if (lim == 0)
        {
            infLim = false;
        }
        else if (lim == 1)
        {
            supLim = false;
        }
    }

    public void StopCrane(int lim)
    {
        if (lim == 0)
        {           
            infLim = true;
        }
        else if (lim == 1)
        {
            supLim = true;
        }
    }
}
