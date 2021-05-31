using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    
    [SerializeField] private GameObject blockObj;
    private Transform spawnPoint;
    GameObject lastBlock;
   
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("blockSpawn").transform;
        GenerateNewBlock();
    }
    


    public void EnableBlockInput()
    {
        lastBlock.GetComponent<BlockScript>().doInput = true;
    }

    public void DisableBlockInput()
    {
        lastBlock.GetComponent<BlockScript>().doInput = false;
    }

    public void GenerateNewBlock()
    {
        GameObject myBlock = Instantiate(blockObj, spawnPoint.position, spawnPoint.rotation);
        myBlock.transform.parent = spawnPoint.transform;
        lastBlock = myBlock;
    }
}
