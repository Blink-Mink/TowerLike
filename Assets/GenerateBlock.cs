using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockObj;
    
    private Transform spawnPoint;
    private Transform pendulo;
    private GameObject lastBlock;
    private bool doInput;

    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("blockSpawn").transform;
        pendulo = GameObject.FindGameObjectWithTag("pendulo").transform;
        GenerateNewBlock();
    }   


    public void EnableBlockInput()
    {
        doInput = true;
    }

    public void DisableBlockInput()
    {
        doInput = false;
    }

    public void GenerateNewBlock()
    {
        GameObject myBlock = Instantiate(blockObj, spawnPoint.position, spawnPoint.rotation);
        myBlock.transform.parent = spawnPoint.transform;
        lastBlock = myBlock;
    }


    void Update()
    {

        if (doInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lastBlock != null)
                {
                    if (lastBlock.gameObject.GetComponent<Rigidbody2D>() == null)
                    {
                        SetRigi();
                        lastBlock.transform.parent = null;
                        pendulo.gameObject.GetComponent<ControlCuerda>().DoCraneOut = true;
                        doInput = false;
                    }
                    else
                    {
                        return;
                    }
                }                
            }
        }

    }

    public void SetRigi()
    {
        lastBlock.AddComponent<Rigidbody2D>();
        lastBlock.GetComponent<Rigidbody2D>().gravityScale = 2;
        lastBlock.GetComponent<Rigidbody2D>().drag = 1;
        lastBlock.GetComponent<Rigidbody2D>().angularDrag = 1;
    }
}
